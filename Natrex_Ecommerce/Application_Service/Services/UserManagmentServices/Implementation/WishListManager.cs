namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class WishListManager : IWishListManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public WishListManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> AddWishListItem(AddWishListItemDto request)
        {
            try
            {
                var wishList = await _unitOfWork.WishLists.FirstOrDefaultAsync(w => w.UserId == request.UserId);

                if (wishList != null)
                {
                    // Check if item already exists — from incoming
                    var existing = await _unitOfWork.WishListItemRepo
                        .QueryWishListItems()
                        .Where(x => x.WishListId == wishList.WishListId && x.ProductId == request.ProductId)
                        .FirstOrDefaultAsync();

                    if (existing != null)
                        return ApiResponse<string>.Fail("Item Already Exists");

                    await _unitOfWork.WishListItemRepo.Create(request.ToWishListItem(wishList.WishListId));
                    await _unitOfWork.SaveChangesAsync();
                    return ApiResponse<string>.Success(default!, "Item added to wish list successfully");
                }

                var newWishList = request.ToWishList();
                await _unitOfWork.WishLists.Create(newWishList);
                await _unitOfWork.WishListItemRepo.Create(request.ToWishListItem(newWishList.WishListId));
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<string>.Success(default!, "Item added to wish list successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail(ex.Message, ResponseType.InternalServerError);
            }
        }

        // Updated signature from incoming — takes Guid directly
        public async Task<ApiResponse<string>> DeleteWishListItem(Guid wishListItemId)
        {
            try
            {
                var wishListItem = await _unitOfWork.WishListItemRepo.FirstOrDefaultAsync(x => x.WishListItemId == wishListItemId);
                if (wishListItem == null)
                    return ApiResponse<string>.Fail("WishListItem Not Found", ResponseType.NotFound);

                await _unitOfWork.WishListItemRepo.Delete(wishListItem.WishListItemId);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<string>.Success(default!, "Item Removed Successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail(ex.Message, ResponseType.InternalServerError);
            }
        }

        public async Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId)
        {
            var wishList = await _unitOfWork.WishLists.FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishList == null)
                return ApiResponse<List<GetWishListItem>>.Fail("WishList Currently is Empty");

            var result = await (
                from w in _unitOfWork.WishListItemRepo
                    .QueryWishListItems()
                    .Where(x => x.WishListId == wishList.WishListId)

                join p in _unitOfWork.ProductRepo.QueryProducts()
                    on w.ProductId equals p.ProductId

                join i in _unitOfWork.ProductImageRepo
                        .QueryProductImages()
                        .Where(img => img.IsPrimary)
                    on p.ProductId equals i.ProductId into imgGroup
                from i in imgGroup.DefaultIfEmpty()

                select new GetWishListItem(
                    w.WishListItemId,
                    p.ProductId,
                    i != null ? i.ImageId : Guid.Empty,
                    i != null ? i.ImageUrl : null,
                    i != null ? i.CloudPublicId : null,
                    p.SellerId,
                    p.ProductName,
                    p.ProductDescription,
                    p.Price,
                    p.Discount
                )
            ).ToListAsync();

            return ApiResponse<List<GetWishListItem>>.Success(result, "Items Retrieved Successfully");
        }

        // New method from incoming ✅
        public async Task<ApiResponse<int>> GetWishListCount(Guid userId)
        {
            try
            {
                var wishList = await _unitOfWork.WishLists.FirstOrDefaultAsync(w => w.UserId == userId);

                if (wishList == null)
                    return ApiResponse<int>.Success(0, "No wishlist found");

                var count = await _unitOfWork.WishListItemRepo.QueryWishListItems()
                    .CountAsync(w => w.WishListId == wishList.WishListId);

                return ApiResponse<int>.Success(count, "Count retrieved");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.Fail(ex.Message, ResponseType.InternalServerError);
            }
        }
    }
}