using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
using Application_Service.DTO_s.UserManagmentDto_s.WishList;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UserManagment;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class WishListManager : IWishListManager
    {
        private readonly IRepository<WishList> _wishListGenericRepo;
        private readonly IRepository<WishListItem> _wishListItemGenericRepo;
        private readonly IWishListRepo _wishListRepo;
        public WishListManager(IRepository<WishList> wishListRepository, IRepository<WishListItem> wishListItemRepository, IWishListRepo wishListRepo)
        {
            _wishListGenericRepo = wishListRepository;
            _wishListItemGenericRepo = wishListItemRepository;
            _wishListRepo = wishListRepo;
        }

        public async Task<ApiResponse<string>> AddWishListItem(AddWishListItemDto request)
        {
            try
            {
                // check wish list exist or not of current user
                var wishList = await _wishListGenericRepo.FirstOrDefaultAsync(w => w.UserId == request.UserId);

                // if exist then add items
                if (wishList != null)
                {
                    await _wishListItemGenericRepo.Create(request.ToWishListItem(wishList.WishListId));
                    await _wishListItemGenericRepo.SaveChangesAsync();
                    return ApiResponse<string>.Success(default!, "Item added to wish list successfully");
                }

                // if wish list not exist then create new wish list for user and add item to it
                var newWishList = request.ToWishList();
                await _wishListGenericRepo.Create(newWishList);
                await _wishListItemGenericRepo.Create(request.ToWishListItem(newWishList.WishListId));
                await _wishListGenericRepo.SaveChangesAsync();
                return ApiResponse<string>.Success(default!, "Item added to wish list successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail(ex.Message, ResponseType.InternalServerError);
            }

        }
        public async Task<ApiResponse<string>> DeleteWishListItem(DeleteWishListItemDto request)
        {
            try
            {
                // find wish list by userId
                var wishList = await _wishListGenericRepo.FirstOrDefaultAsync(w => w.UserId == request.UserId);
                if (wishList == null)
                    return ApiResponse<string>.Fail("WishList Not Found", ResponseType.NotFound);

                // remove the selected item
                var wishListItem = await _wishListItemGenericRepo.FirstOrDefaultAsync(w => w.ProductId == request.ProductId);
                if (wishListItem == null)
                    return ApiResponse<string>.Fail("WishListItem  Not Found", ResponseType.NotFound);

                await _wishListItemGenericRepo.Delete(wishListItem!.WishListItemId);
                await _wishListItemGenericRepo.SaveChangesAsync();
                return ApiResponse<string>.Success(default!, "Item Removed Succefuly");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail(ex.Message, ResponseType.InternalServerError);
            }
        }

        public async Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId)
        {
            throw new NotImplementedException();
            //var wishList = await _wishListGenericRepo.FirstOrDefaultAsync(w => w.UserId == userId);
            //if (wishList == null)
            //    return ApiResponse<List<GetWishListItem>>.Fail("WishList Currently is Empty");

            //var wishListItems = await _wishListRepo.GetAllWishListItemsByWishListId(wishList!.WishListId);
            //var
        }
    }
}
