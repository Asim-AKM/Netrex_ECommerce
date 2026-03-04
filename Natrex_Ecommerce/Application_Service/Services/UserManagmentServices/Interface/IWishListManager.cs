using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
using Application_Service.DTO_s.UserManagmentDto_s.WishList;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IWishListManager
    {
        Task<ApiResponse<Guid>> AddWishListItem(AddWishListItemDto request);
        Task<ApiResponse<string>> DeleteWishListItem(Guid wishListItemid);
        Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId);
        Task<ApiResponse<int>> GetWishListCount(Guid userId);
    }
}
