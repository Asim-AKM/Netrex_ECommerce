using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartDtos
{
    public record GetCartDto
 (
     /// <summary>
     /// The unique identifier of the Cart.
     /// This field is system-generated and uniquely identifies the Cart in the database.
     /// </summary>
     Guid CartId,

     /// <summary>
     /// The unique identifier of the Customer who owns the Cart.
     /// </summary>
     Guid CustomerId
 );
}
