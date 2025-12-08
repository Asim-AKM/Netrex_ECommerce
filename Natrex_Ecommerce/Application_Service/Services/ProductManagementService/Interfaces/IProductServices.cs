using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductServices
    {
        Task AddProduct(AddProductDto productDto, Guid loggedInSellerId);
    }
}
