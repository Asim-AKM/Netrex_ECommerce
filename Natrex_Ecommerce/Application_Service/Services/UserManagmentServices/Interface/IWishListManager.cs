namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IWishListManager
    {
        Task<ApiResponse<string>> AddWishListItem(AddWishListItemDto request);
        Task<ApiResponse<string>> DeleteWishListItem(DeleteWishListItemDto request);
        Task<ApiResponse<List<GetWishListItem>>> GetWishListItems(Guid userId);
    }
}
