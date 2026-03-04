using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.UserManagmentMapppers;
using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
using Application_Service.DTO_s.UserManagmentDto_s.WishList;
using Application_Service.Services.ProductManagementService.Implementation;
using Application_Service.Services.ProductManagementService.Interfaces;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Domain_Service.RepoInterfaces.UserManagment;
using Microsoft.EntityFrameworkCore;

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
                // check wish list exist or not of current user
                var wishList = await _unitOfWork.WishLists.FirstOrDefaultAsync(w => w.UserId == request.UserId);

                // if exist then add items
                if (wishList != null)
                {
                    await _unitOfWork.WishListItemRepo.Create(request.ToWishListItem(wishList.WishListId));
                    await _unitOfWork.SaveChangesAsync();
                    return ApiResponse<string>.Success(default!, "Item added to wish list successfully");
                }

                // if wish list not exist then create new wish list for user and add item to it
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
        public async Task<ApiResponse<string>> DeleteWishListItem(DeleteWishListItemDto request)
        {
            try
            {
                // find wish list by userId
                var wishList = await _unitOfWork.WishLists.FirstOrDefaultAsync(w => w.UserId == request.UserId);
                if (wishList == null)
                    return ApiResponse<string>.Fail("WishList Not Found", ResponseType.NotFound);

                // remove the selected item
                var wishListItem = await _unitOfWork.WishListItemRepo.FirstOrDefaultAsync(w => w.ProductId == request.ProductId);
                if (wishListItem == null)
                    return ApiResponse<string>.Fail("WishListItem  Not Found", ResponseType.NotFound);

                await _unitOfWork.WishListItemRepo.Delete(wishListItem!.WishListItemId);
                await _unitOfWork.SaveChangesAsync();
                return ApiResponse<string>.Success(default!, "Item Removed Succefuly");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.Fail(ex.Message, ResponseType.InternalServerError);
            }
        }

        public async Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId)
        {
            var wishList = await _unitOfWork.WishLists
                .FirstOrDefaultAsync(w => w.UserId == userId);

            if (wishList == null)
                return ApiResponse<List<GetWishListItem>>
                    .Fail("WishList Currently is Empty");

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

            return ApiResponse<List<GetWishListItem>>
                .Success(result, "Items Retrieved Successfully");
        }
    }
}
