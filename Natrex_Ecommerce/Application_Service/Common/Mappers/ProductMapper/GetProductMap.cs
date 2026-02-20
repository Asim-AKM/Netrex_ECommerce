using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class GetProductMap
    {
        public static GetProductDto MapToGetProductDto(Product product, List<ProductImage> images)
        {
            var primary = images.FirstOrDefault(img => img.IsPrimary) ?? images.FirstOrDefault();
            return new GetProductDto
            {
                productId = product.ProductId,
                sellerId = product.SellerId,
                productcatorgayId = product.ProductCategoryId,
                productName = product.ProductName,
                productDescription = product.ProductDescription,
                price = product.Price,
                discount = product.Discount,
                stockQuantity = product.StockQuantity,
                createdAt = product.CreatedAt,
                updatedAt = product.UpdatedAt,
                ImgeId = primary!.ImageId,
                ImageUrl = primary?.ImageUrl,
                CloudPublicId = primary?.CloudPublicId,
                Images = images.Select(img => new ImagesDto
                {
                    ImageUrl = img.ImageUrl,
                    CloudPublicId = img.CloudPublicId,
                    IsPrimary = img.IsPrimary
                }).ToList()
            };
        }


    }
}
