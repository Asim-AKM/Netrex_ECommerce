using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductManager
    {
        Task<ApiResponse<AddProductDto>> AddProduct(AddProductDto productDto);
        Task<ApiResponse<string>> UpdateProduct(UpdateProductDTOS productDto);
        
        Task<ApiResponse<string>> DeleteProduct(Guid productId);
        Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId);
    }
}
