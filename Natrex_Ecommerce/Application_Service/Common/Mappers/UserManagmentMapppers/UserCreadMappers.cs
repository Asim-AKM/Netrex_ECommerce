using Application_Service.Services.UserManagmentServices.Implementation;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class UserCreadMappers
    {
        public static UserCreadential AssignCreads(this User user, string password)
        {
            PasswordEncriptor encryptor = new();
            encryptor.CreateHashAndSalt(password, out byte[] newHash, out byte[] newSalt);
            return new UserCreadential
            {
                CreadId = Guid.NewGuid(),
                UserId = user.UserId,
                PasswordHash = newHash,
                PasswordSalt = newSalt,
                OTP = string.Empty
            };
        }
    }
}
