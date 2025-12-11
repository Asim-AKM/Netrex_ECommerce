using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductManager
    {
        Task AddProduct(AddProductDto productDto);
        Task UpdateProduct(UpdateProductDTOS productDto);
    }
}
