using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartDtos
{
    public record UpdateCartDto(Guid CartId, Guid CustomerId);
     
}
