using Application_Service.DTO_s.UsersDto.Accounts;
using Domain_Service.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.UserMapper
{
    public static class UserRegistrationMappers
    {
        public static User Map(this UserRegisterDto registerDto)
        {
            return new User
            {
                U_Id = Guid.NewGuid(),
                UserName = registerDto.username,
                Email = registerDto.email,
                Contact = registerDto.contact,
            };
        }

      
    }
}
