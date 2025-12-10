using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.UsersDto.Accounts
{
    public record CreateUserDto(string email,string password,string contact,string username);
   
}
