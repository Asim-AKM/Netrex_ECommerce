using Application_Service.DTO_s.UsersDto.Accounts;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class UserMappers
    {
        public static User MapToDomain(this CreateUserDto registerDto)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                UserName = registerDto.username,
                Email = registerDto.email,
                Contact = registerDto.contact,
            };
        }

      
    }
}
