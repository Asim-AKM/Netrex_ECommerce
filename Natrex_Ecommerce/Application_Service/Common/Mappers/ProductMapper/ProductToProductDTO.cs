namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class ProductToProductDTO
    {

        public static Product MapProduct(this AddProductDto productDto, Guid categoryId)
        {
           
            return new Product
            {
                ProductId = Guid.NewGuid(),
                SellerId = productDto.SellerId,
                ProductCategoryId = categoryId,
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                Price = productDto.Price,              // ✅ Original price
                Discount = productDto.Discount,        // ✅ Discount percentage
                StockQuantity = productDto.StockQuantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

    }
}
