using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.UserManagmentDto_s
{
    public record UpdateCustomerDto(Guid CustomerId, string City,string Province,string Country,string Address);
    

    
}
