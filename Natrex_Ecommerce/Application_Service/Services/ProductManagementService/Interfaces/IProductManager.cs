using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.LocationModules;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductManager
    {
        Task<ApiResponse<AddProductDto>> AddProduct(AddProductDto productDto);
        Task<ApiResponse<string>> UpdateProduct(UpdateProductDTOS productDto);
        
        Task<ApiResponse<string>> DeleteProduct(Guid productId);
        Task<ApiResponse<GetProductDto>> GetByProductId(Guid productId);

        Task<ApiResponse<List<GetProvinceDto>>> GetAllProvinces();
        Task<ApiResponse<List<GetCityDto>>> GetCitiesByProvinceId(Guid Id);
    }
}
