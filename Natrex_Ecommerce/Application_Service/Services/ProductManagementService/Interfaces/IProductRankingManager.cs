namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductRankingManager
    {
        Task<ApiResponse<List<GetProductDto>>> GetBestSellersAsync();
        Task<ApiResponse<List<GetProductDto>>> GetTrendingAsync();
        Task<ApiResponse<List<GetProductDto>>> GetTopRatedAsync();
        Task<ApiResponse<List<GetProductDto>>> GetHomepageProductsAsync(Guid? categoryid = null,int pageNumber = 1,int pageSize = 10);
        Task<ApiResponse<List<GetProductDto>>> GetNewArrivalsAsync();
    }
}
