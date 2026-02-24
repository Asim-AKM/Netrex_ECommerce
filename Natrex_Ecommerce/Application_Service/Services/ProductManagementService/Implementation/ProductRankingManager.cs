using Application_Service.Common.APIResponses;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.ProductRepo;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductRankingManager : IProductRankingManager
    {
        private readonly IProductRankingRepo _productRankingRepo;   
        public ProductRankingManager(IProductRankingRepo productRankingRepo)
        {
            _productRankingRepo = productRankingRepo;
        }
        public async Task<ApiResponse<List<Product>>> GetBestSellersAsync()
        {
            var product= await _productRankingRepo.GetBestSellersAsync();
            return ApiResponse<List<Product>>.Success(product, "Best sellers retrieved successfully");
        }

        public async Task<ApiResponse<List<Product>>> GetHomepageProductsAsync()
        {
            var product= await _productRankingRepo.GetHomepageProductsAsync();
            return ApiResponse<List<Product>>.Success(product, "Homepage products retrieved successfully");
        }

        public async Task<ApiResponse<List<Product>>> GetNewArrivalsAsync()
        {
            var product= await _productRankingRepo.GetNewArrivalsAsync();
            return ApiResponse<List<Product>>.Success(product, "New arrivals retrieved successfully");
        }

        public async Task<ApiResponse<List<Product>>> GetTopRatedAsync()
        {
            var product= await _productRankingRepo.GetTopRatedAsync();
            return ApiResponse<List<Product>>.Success(product, "Top rated products retrieved successfully");
        }

        public async Task<ApiResponse<List<Product>>> GetTrendingAsync()
        {
            var product= await _productRankingRepo.GetTrendingAsync();
            return ApiResponse<List<Product>>.Success(product, "Trending products retrieved successfully");
        }
    }
}