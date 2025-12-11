using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class UpdateProductMap
    {
        public static void Mapping(this UpdateProductDTOS dto, Product domain)
        {
            var discountPercentage = Math.Clamp(dto.Discount, 0, 100);
            var discountAmount = dto.Price * (discountPercentage / 100);
            var finalPrice = Math.Max(dto.Price - discountAmount, 0);
            domain.ProductName = dto.ProductName; 
            domain.ProductDescription = dto.ProductDescription;
            domain.Price = finalPrice;
            domain.Discount = discountPercentage;
            domain.StockQuantity = dto.StockQuantity;
            domain.UpdatedAt = DateTime.UtcNow;
            

        }
    }
}
