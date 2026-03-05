namespace Application_Service.Common.Mappers.ProductMapper.ProductViewAndReviewMappers
{
    public static class ProductReviewDtoToActual
    {
        public static ProductReview ToProductReview(this AddProductReviewsDto dto)
        {
            return new ProductReview
            {
                ReviewId = Guid.NewGuid(),
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                IsApproved = false, // New reviews are not approved by default
                IPAddress = dto.IPAddress,
                CreatedAt = DateTime.UtcNow
            };
        }
        public static AddProductReviewsDto ToDto(this ProductReview entity)
        {
            return new AddProductReviewsDto(
                  entity.ReviewId,
                  entity.ProductId,
                  entity.CustomerId,
                  entity.Rating,
                  entity.Comment,
                  entity.CreatedAt,
                  entity.IPAddress,
                  entity.IsApproved
               );
        }
    }
}
