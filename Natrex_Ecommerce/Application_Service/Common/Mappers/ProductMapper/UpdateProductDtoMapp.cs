using Domain_Service.Entities.ProductAndCategoryModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class UpdateProductDtoMapp
    {
        public static Product Map(this DTO_s.ProductDTOS.UpdateProductDto updateProductDto)
        {
            if (updateProductDto is null)
            {
                throw new ArgumentNullException(nameof(updateProductDto));
            }
            return new Product
            {
                ProductId = updateProductDto.productId,
                SellerId = updateProductDto.sellerId,
                ProductCategoryId = updateProductDto.productCategoryId,
                ProductName = updateProductDto.productName,
                ProductDescription = updateProductDto.productDescription,
                Price = updateProductDto.price,
                Discount = updateProductDto.discount,
                StockQuantity = updateProductDto.stockQuantity,
                CreatedAt = updateProductDto.createdAt,
                UpdatedAt = updateProductDto.updatedAt
            };
        }
    }
}
