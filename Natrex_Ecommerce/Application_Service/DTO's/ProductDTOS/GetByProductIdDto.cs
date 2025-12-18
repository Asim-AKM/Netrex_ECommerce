using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.ProductDTOS
{
    public  record GetByProductIdDto( Guid productId, Guid ImgeId, Guid sellerId, Guid productcatorgayId, string productName, string productDescription, double price,
                                                     double discount, int stockQuantity, DateTime createdAt, DateTime updatedAt);


}
