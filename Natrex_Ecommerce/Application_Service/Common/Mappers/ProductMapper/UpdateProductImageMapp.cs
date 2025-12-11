using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class UpdateProductImageMapp
    {
        public static void MapToExistingImage(this UpdateProductDTOS dto, ProductImage existing)
        {
            existing.ImageUrl = dto.ImageUrl;
            existing.IsPrimary = true;
            existing.LastUpdatedAt = DateTime.UtcNow;
        }
    }
}
