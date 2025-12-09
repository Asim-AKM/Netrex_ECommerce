using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class ProductImageToProductDTO
    {
        public static ProductImage MapProductImage(this AddProductDto productImage , Guid prodId)
        {
            return new ProductImage
            {
                ImageId = Guid.NewGuid(),
                ProductId = prodId,
                ImageUrl = productImage.ImageUrl,
                IsPrimary = true,
                UploadedAt = DateTime.UtcNow,
            };
        }
    }
}