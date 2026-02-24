using Application_Service.Common.APIResponses;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductRankingManager
    {
        Task<ApiResponse<List<Product>>> GetBestSellersAsync();
        Task<ApiResponse<List<Product>>> GetTrendingAsync();
        Task<ApiResponse<List<Product>>> GetTopRatedAsync();
        Task<ApiResponse<List<Product>>> GetHomepageProductsAsync();
        Task<ApiResponse<List<Product>>> GetNewArrivalsAsync();
    }
}
