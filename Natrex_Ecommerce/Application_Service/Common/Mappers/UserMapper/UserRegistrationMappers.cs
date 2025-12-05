using Application_Service.DTO_s.UserManagmentDto_s;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Common.Mappers.UserMapper
{
    public static class UserRegistrationMappers
    {
        public static User Map(this UserRegisterDto registerDto)
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
