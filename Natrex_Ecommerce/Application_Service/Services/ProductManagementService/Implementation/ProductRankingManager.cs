namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductRankingManager : IProductRankingManager
    {
        private readonly IProductRankingRepo _productRankingRepo;
        private readonly IProductImageRepo _productImageRepo;
        public ProductRankingManager(IProductRankingRepo productRankingRepo, IProductImageRepo productImageRepo)
        {
            _productRankingRepo = productRankingRepo;
            _productImageRepo = productImageRepo;
        }
        public async Task<ApiResponse<List<GetProductDto>>> GetBestSellersAsync()
        {
            var product= await _productRankingRepo.GetBestSellersAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _productImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Best sellers retrieved successfully");
        }
        public async Task<ApiResponse<List<GetProductDto>>> GetHomepageProductsAsync(Guid? categoryid = null,int pageNumber = 1,int pageSize = 10)
        {
            var product = await _productRankingRepo
                .GetHomepageProductsAsync(categoryid, pageNumber, pageSize);

            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>
                    .Fail("No products found", ResponseType.NotFound);

            var images = await _productImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);

            return ApiResponse<List<GetProductDto>>
                .Success(dto, "Homepage products retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetNewArrivalsAsync()
        {
            var product= await _productRankingRepo.GetNewArrivalsAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _productImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "New arrivals retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetTopRatedAsync()
        {
            var product= await _productRankingRepo.GetTopRatedAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);
            var images = await _productImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Top rated products retrieved successfully");
        }

        public async Task<ApiResponse<List<GetProductDto>>> GetTrendingAsync()
        {
            var product= await _productRankingRepo.GetTrendingAsync();
            if (product == null || !product.Any())
                return ApiResponse<List<GetProductDto>>.Fail("No products found", ResponseType.NotFound);   
            var images = await _productImageRepo.GetAllProductImages();
            var dto = product.GetAllProducts(images);
            return ApiResponse<List<GetProductDto>>.Success(dto, "Trending products retrieved successfully");
        }
    }
}