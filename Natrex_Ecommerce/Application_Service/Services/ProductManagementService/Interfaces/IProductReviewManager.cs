using Application_Service.DTO_s.ProductDTOS;

namespace Application_Service.Services.ProductManagementService.Interfaces
{
    public interface IProductReviewManager
    {
        Task<string> AddReviewAsync(AddProductReviewsDto dto);
        Task<List<AddProductReviewsDto>> GetReviewsByProductIdAsync(Guid productId);
        Task ApproveReviewAsync(Guid reviewId);
    }
}
