using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class GetAllProductsMapper
    {
        public static List<GetProductDto> GetAllProducts(
     this List<Product> products,
     List<ProductImage> images)
        {
            if (products == null)
                return new List<GetProductDto>();

            return products.SelectMany(product =>
            {
                var productImages = images
                    .Where(img => img.ProductId == product.ProductId)
                    .ToList();

              
                if (!productImages.Any())
                {
                    return new List<GetProductDto>
            {
                new GetProductDto(
                    product.ProductId,              
                    Guid.Empty,                    
                    product.SellerId,               
                    product.ProductCategoryId,     
                    product.ProductName,           
                    product.ProductDescription,     
                    product.Price,                  
                    product.Discount,              
                    product.StockQuantity,          
                    null,                           
                    null,                           
                    product.CreatedAt,             
                    product.UpdatedAt              
                )
            };
                }

               
                return productImages.Select(img => new GetProductDto(
                    product.ProductId,             
                    img.ImageId,                    
                    product.SellerId,               
                    product.ProductCategoryId,     
                    product.ProductName,            
                    product.ProductDescription,     
                    product.Price,                  
                    product.Discount,               
                    product.StockQuantity,         
                    img.ImageUrl,                  
                    img.CloudPublicId,              
                    product.CreatedAt,             
                    product.UpdatedAt               
                ));
            }).ToList();
        }

    }
}
