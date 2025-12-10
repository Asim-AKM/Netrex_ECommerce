using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class UpdateProductMap
    {
        public static void MapToExisting(this UpdateProductDTOS dto, Product existing)
        {
            var discountPercentage = Math.Clamp(dto.Discount, 0, 100);
            var discountAmount = dto.Price * (discountPercentage / 100);
            var finalPrice = Math.Max(dto.Price - discountAmount, 0);
           
            existing.ProductName = dto.ProductName;
            existing.ProductDescription = dto.ProductDescription;
            existing.Discount = discountPercentage;
            existing.Price = finalPrice;
            existing.StockQuantity = dto.StockQuantity;
            existing.UpdatedAt = DateTime.UtcNow;
        }
    }
}
