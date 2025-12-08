using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.UserManagmentDto_s
{
    public record UpdateUserDto(Guid Id, string FullName, string ImageUrl, string UserName,string Email,string Contact);
   
}
