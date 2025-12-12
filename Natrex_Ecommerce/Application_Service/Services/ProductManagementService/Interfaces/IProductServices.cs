using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductServices
    {
        Task AddProduct(AddProductDto productDto);
        Task<bool> DeleteProduct(Guid productId); 
        Task<GetByProductIdDto> GetByProductId(Guid productId);
    }
}
