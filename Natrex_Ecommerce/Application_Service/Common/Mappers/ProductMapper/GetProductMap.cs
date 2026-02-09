using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class GetProductMap
    {
        public static GetProductDto MapToGetProductDto(Product product, ProductImage? productImage)
        {
            return new GetProductDto(
            product.ProductId,
            productImage?.ImageId ?? Guid.Empty,
            product.SellerId,
            product.ProductCategoryId,
            product.ProductName,
            product.ProductDescription,
            product.Price,
            product.Discount,
            product.StockQuantity,
            productImage?.ImageUrl ?? string.Empty,
            productImage?.CloudPublicId ?? string.Empty,
            product.CreatedAt,
            product.UpdatedAt
            );
        }


    }
}
