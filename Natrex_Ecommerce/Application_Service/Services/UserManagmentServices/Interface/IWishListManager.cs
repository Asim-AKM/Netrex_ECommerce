namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IWishListManager
    {
        Task<ApiResponse<string>> AddWishListItem(AddWishListItemDto request);
        Task<ApiResponse<string>> DeleteWishListItem(Guid wishListItemid);
        Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId);
        Task<ApiResponse<int>> GetWishListCount(Guid userId);
    }
}
