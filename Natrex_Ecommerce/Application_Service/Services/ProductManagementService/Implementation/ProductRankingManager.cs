using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.ProductMapper;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductRankingManager : IProductRankingManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRankingManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<List<GetProductDto>>> GetBestSellersAsync()
        {
            var product= await _unitOfWork.ProductRankingRepo.GetBestSellersAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Best sellers retrieved successfully");
        }
        public async Task<ApiResponse<List<GetProductDto>>> GetHomepageProductsAsync(Guid? categoryid = null,int pageNumber = 1,int pageSize = 10)
        {
            var product = await _unitOfWork.ProductRankingRepo
                .GetHomepageProductsAsync(categoryid, pageNumber, pageSize);

            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>
                    .Fail("No products found", ResponseType.NotFound);

            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);

            return ApiResponse<List<GetProductDto>>
                .Success(dto, "Homepage products retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetNewArrivalsAsync()
        {
            var product= await _unitOfWork.ProductRankingRepo.GetNewArrivalsAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "New arrivals retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetTopRatedAsync()
        {
            var product= await _unitOfWork.ProductRankingRepo.GetTopRatedAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Top rated products retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetTrendingAsync()
        {
            var product= await _unitOfWork.ProductRankingRepo.GetTrendingAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);   
            var images = await _unitOfWork.ProductImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Trending products retrieved successfully");
        }
    }
}