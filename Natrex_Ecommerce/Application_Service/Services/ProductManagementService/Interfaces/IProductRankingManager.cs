using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductRankingManager
    {
        Task<ApiResponse<List<GetProductDto>>> GetBestSellersAsync();
        Task<ApiResponse<List<GetProductDto>>> GetTrendingAsync();
        Task<ApiResponse<List<GetProductDto>>> GetTopRatedAsync();
        Task<ApiResponse<List<GetProductDto>>> GetHomepageProductsAsync();
        Task<ApiResponse<List<GetProductDto>>> GetNewArrivalsAsync();
    }
}
