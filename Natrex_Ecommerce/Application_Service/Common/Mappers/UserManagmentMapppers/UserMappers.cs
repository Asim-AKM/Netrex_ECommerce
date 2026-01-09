using Application_Service.DTO_s.UserManagmentDto_s;
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
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FullName = registerDto.FullName,
            };
        }
        public static User MapToDomain(this UpdateUserDto userdto)
        {
            return new User()
            {
                FullName = userdto.FullName,
                ImageUrl = userdto.ImageUrl,
                UserName = userdto.UserName,
                Email = userdto.Email,
                Contact=userdto.Contact,
                UpdatedAt= DateTime.UtcNow
            };
        }


    }
}
