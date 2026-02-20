using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class ProductImageToProductDTO
    {
        public static ProductImage ToProductImage(this ImagesDto dto, Guid productId)
        {
            return new ProductImage
            {
                ImageId = Guid.NewGuid(),
                ProductId = productId,
                ImageUrl = dto.ImageUrl,
                CloudPublicId = dto.CloudPublicId,
                IsPrimary = dto.IsPrimary,
                UploadedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
        }
        public static List<ProductImage> ToProductImages(this List<ImagesDto> dtos, Guid productId)
        {
            return dtos.Select(dto => dto.ToProductImage(productId)).ToList();
        }
    }
}