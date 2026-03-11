namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductManager
    {
        Task<ApiResponse<AddProductDto>> AddProduct(AddProductDto productDto);
        Task<ApiResponse<string>> UpdateProduct(UpdateProductDTOS productDto);
        
        Task<ApiResponse<bool>> DeleteProduct(Guid productId);
        Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId);
        Task<ApiResponse<List<GetProductDto>>> GetAllProducts(Guid SellerId);
        Task<ApiResponse<List<GetProvinceDto>>> GetAllProvinces();
        Task<ApiResponse<List<GetCityDto>>> GetCitiesByProvinceId(Guid Id);
        Task<ApiResponse<List<ProductCategoryDto>>> GetCategoriesAsync();
    }
}
