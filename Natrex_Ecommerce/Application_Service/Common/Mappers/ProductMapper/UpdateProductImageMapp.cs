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
