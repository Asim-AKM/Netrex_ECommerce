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
            // 1. Check if user already reviewed this product
            bool alreadyReviewed = await _unitofWork.ProductReview.AnyAsync(x =>
                x.ProductId == dto.ProductId && x.CustomerId == dto.CustomerId);

            if (alreadyReviewed)
                return "You have already reviewed this product.";

            // 2. Map DTO to entity
            var review = dto.ToProductReview();

            // 3. Insert review into ProductReview table

            // 4. Update Product AverageRating and TotalReviews incrementally
            var product = await _unitofWork.Products.GetById(dto.ProductId);
            if (product != null)
            {
                decimal currentAverage = product.AverageRating;
                int currentTotal = product.TotalReviews;

                decimal updatedAverage = ((currentAverage * currentTotal) + dto.Rating) / (currentTotal + 1);

                product.AverageRating = updatedAverage;
                product.TotalReviews = currentTotal + 1;

                await _unitofWork.ProductReview.Create(review);
                await _unitofWork.Products.Update(product);
                await _unitofWork.SaveChangesAsync();
                return "Review added successfully";
            }
            else
            {
                return "Product not found";
            }
        }

        public async Task ApproveReviewAsync(Guid reviewId)
        {
            var data = await _unitofWork.ProductReview.GetById(reviewId);
            if (data == null)
            {
                throw new Exception("Review not found");
            }
            data.IsApproved = true;
            await _unitofWork.ProductReview.Update(data);
            await _unitofWork.SaveChangesAsync();
        }

        public async Task<List<AddProductReviewsDto>> GetReviewsByProductIdAsync(Guid productId)
        {
            var result = (await _unitofWork.ProductReview.GetAll())
        .AsQueryable()
        .Where(x => x.ProductId == productId && x.IsApproved)
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => x.ToDto())
        .ToList();
            return result;
        }
    }
}
