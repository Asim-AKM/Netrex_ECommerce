using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
using Application_Service.DTO_s.UserManagmentDto_s.WishList;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IWishListManager
    {
        Task<ApiResponse<string>> AddWishListItem(AddWishListItemDto request);
        Task<ApiResponse<string>> DeleteWishListItem(DeleteWishListItemDto request);
        Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId);
    }
}
