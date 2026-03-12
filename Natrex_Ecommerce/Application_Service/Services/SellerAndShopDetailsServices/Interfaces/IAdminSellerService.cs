namespace Application_Service.Services.SellerAndShopDetailsServices.Interfaces
{
    public interface IAdminSellerService
    {
        Task<ApiResponse<List<GetSellerDto>>> GetPendingSellersAsync();
        Task<ApiResponse<GetSellerDto>> ApproveSellerAsync(Guid sellerId);
        Task<ApiResponse<GetSellerDto>> RejectSellerAsync(Guid sellerId);
        Task<ApiResponse<GetSellerDto>> SuspendSellerAsync(Guid sellerId);
    }
}
