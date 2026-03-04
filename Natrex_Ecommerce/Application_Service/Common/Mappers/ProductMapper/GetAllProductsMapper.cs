using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class GetAllProductsMapper
    {
        public static List<GetProductDto> GetAllProducts(this List<Product> products, List<ProductImage> images)
        {
            return products.Select(product =>
            {
                var productImages = images.Where(img => img.ProductId == product.ProductId).ToList();
                var primary = productImages.FirstOrDefault(img => img.IsPrimary) ?? productImages.FirstOrDefault();

                return new GetProductDto
                {
                    productId = product.ProductId,
                    ImgeId = primary?.ImageId ?? Guid.Empty,
                    sellerId = product.SellerId,
                    productcatorgayId = product.ProductCategoryId,
                    productName = product.ProductName,
                    productDescription = product.ProductDescription,
                    price = product.Price,
                    discount = product.Discount,
                    stockQuantity = product.StockQuantity,
                    ImageUrl = primary?.ImageUrl,
                    CloudPublicId = primary?.CloudPublicId,
                    createdAt = product.CreatedAt,
                    updatedAt = product.UpdatedAt,
                    AverageRating = product.AverageRating,
                    TotalViews=product.TotalViews,
                    TotalReviews=product.TotalReviews,
                    Images = productImages.Select(img => new ImagesDto
                    {
                        ImageUrl = img.ImageUrl,
                        CloudPublicId = img.CloudPublicId,
                        IsPrimary = img.IsPrimary
                    }).ToList()
                };
            }).ToList();
        }

    }
}
