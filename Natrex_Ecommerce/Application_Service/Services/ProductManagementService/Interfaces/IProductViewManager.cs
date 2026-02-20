using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductViewManager
    {
        Task<string> AddViewAsync(AddProductViewDto dto);
        Task<int> GetTotalViewsByProductIdAsync(Guid productId);
    }
}
