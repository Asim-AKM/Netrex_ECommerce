namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class UserSessionMappers
    {
        public static UserSession MapToDomain(this AddUserSessionDto addUserSessionDto)
        {
            var userSession = new UserSession
            {
                SessionId = Guid.NewGuid(),
                UserId = addUserSessionDto.UserId,
                RefreshToken = addUserSessionDto.RefreshToken,
                ExpireAt = DateTime.UtcNow.AddDays(7),
                IsRevoked= false,
                CreatedAt = DateTime.UtcNow,
            };
            return userSession;
        }
    }
}
