using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.ProductDTOS
{
    public record UpdateProductDto(
    Guid productId, Guid sellerId, Guid productCategoryId, string productName, 
    string productDescription, Decimal price, Decimal discount, int stockQuantity, 
    DateTime createdAt, DateTime updatedAt);
    
}
