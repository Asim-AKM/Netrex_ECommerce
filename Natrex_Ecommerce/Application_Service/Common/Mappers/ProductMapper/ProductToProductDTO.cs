using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class ProductToProductDTO
    {

        public static Product MapProduct(this AddProductDto productDto)
        {
            // Ensure discount is between 0 and 100
            var discountPercentage = Math.Clamp(productDto.Discount, 0, 100);

            var discountAmount = productDto.Price * (discountPercentage / 100);
            var finalPrice = productDto.Price - discountAmount;

            // Ensure final price is not negative
            finalPrice = Math.Max(finalPrice, 0);

            return new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Discount = discountAmount,   // Discount amount
                Price = finalPrice,          // Price after discount
                StockQuantity = productDto.StockQuantity,
                CreatedAt = DateTime.UtcNow  
            };
        }

    }
}
