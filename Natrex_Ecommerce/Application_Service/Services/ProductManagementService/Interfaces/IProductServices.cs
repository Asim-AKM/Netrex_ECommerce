using Application_Service.DTO_s.ProductDTOS;
using Microsoft.AspNetCore.Http.Metadata;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductServices
    {
        Task AddProduct(AddProductDto productDto);
        Task<bool> DeleteProduct(Guid productId);
        Task <UpdateProductDto> UpdateProduct(UpdateProductDto productDto);
       
    }
}
