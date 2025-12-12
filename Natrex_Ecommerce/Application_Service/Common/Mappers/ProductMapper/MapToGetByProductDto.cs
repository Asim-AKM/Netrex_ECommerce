using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class MapToGetByProductDto
    {
        public static GetByProductIdDto MapToGetbyProductDto(Product product, ProductImage? productImage)
        {
            return new GetByProductIdDto(
                product.ProductId,
                productImage?.ImageId ?? Guid.Empty,
                product.SellerId,
                product.ProductCategoryId,
                product.ProductName,
                product.ProductDescription,
                product.Price,
                product.Discount,
                product.StockQuantity,
                product.CreatedAt,
                product.UpdatedAt
            );
        }
    }
}
