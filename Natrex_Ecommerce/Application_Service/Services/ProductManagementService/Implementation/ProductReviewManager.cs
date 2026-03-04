using Application_Service.Common.Mappers.ProductMapper.ProductViewAndReviewMappers;
using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.ProductManagementService.Implementation
{
    public class ProductReviewManager : IProductReviewManager
    {
        private readonly IUnitOfWork _unitofWork;
        public ProductReviewManager(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public async Task<string> AddReviewAsync(AddProductReviewsDto dto)
        {
            bool alreadyReviewed = await _unitofWork.ProductReviews.AnyAsync(x =>
                x.ProductId == dto.ProductId && x.CustomerId == dto.CustomerId);
            if (alreadyReviewed)
                return "You have already reviewed this product.";

            var product = await _unitofWork.ProductRepo.GetById(dto.ProductId);
            if (product == null)
                return "Product not found";

            var review = dto.ToProductReview();

            try
            {
                await _unitofWork.ExecuteInTransactionAsync(async () =>
                {
                    decimal updatedAverage = ((product.AverageRating * product.TotalReviews) + dto.Rating) / (product.TotalReviews + 1);
                    product.AverageRating = updatedAverage;
                    product.TotalReviews = product.TotalReviews + 1;

                    await _unitofWork.ProductReviews.Create(review);
                    await _unitofWork.ProductRepo.Update(product);
                });

                return "Review added successfully";
            }
            catch (Exception ex)
            {
                return $"Failed to add review: {ex.Message}";
            }
        }

        public async Task ApproveReviewAsync(Guid reviewId)
        {
            var data = await _unitofWork.ProductReviews.GetById(reviewId);
            if (data == null)
            {
                throw new Exception("Review not found");
            }
            data.IsApproved = true;
            await _unitofWork.ProductReviews.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<List<AddProductReviewsDto>> GetReviewsByProductIdAsync(Guid productId)
        {
            var result = (await _unitofWork.ProductReviews.GetAll())
        .AsQueryable()
        .Where(x => x.ProductId == productId && x.IsApproved)
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => x.ToDto())
        .ToList();
            return result;
        }
    }
}
