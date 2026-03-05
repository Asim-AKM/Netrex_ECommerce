namespace Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface
{
    public interface ICartItemManager
    {
        Task<ApiResponse<bool>> CreateAsync(AddCartItemDto dto,Guid userId);
        Task<ApiResponse<List<GetCartItemDto>>> GetAllAsync(Guid customerId);
        Task<ApiResponse<bool>> IncreaseQuantityAsync(Guid cartItemId);
        Task<ApiResponse<bool>> DecreaseQuantityAsync(Guid cartItemId);
        Task<ApiResponse<bool>> DeleteAsync(Guid cartItemId);
    }
}
