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
                Status = UserStatus.Pending, 
                CreateAt = DateOnly.FromDateTime(DateTime.UtcNow),
                UpdatedAt = DateTime.UtcNow
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
