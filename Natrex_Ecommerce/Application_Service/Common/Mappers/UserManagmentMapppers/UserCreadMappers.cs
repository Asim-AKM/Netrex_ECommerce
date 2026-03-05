namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class UserCreadMappers
    {
        public static UserCreadential AssignCreads(this User user, string password)
        {
            PasswordEncriptor encryptor = new();
            encryptor.CreateHashAndSalt(password, out byte[] newSalt, out byte[] newHash);
            return new UserCreadential
            {
                CreadId = Guid.NewGuid(),
                UserId = user.UserId,
                PasswordHash = newHash,
                PasswordSalt = newSalt,
                OTP = new Random().Next(100000, 999999).ToString(),
                OTPExpiry = DateTime.UtcNow.AddMinutes(5)

            };
        }
        public static UserCreadential UpdateCreads(this UserCreadential userCread, string newPassword)
        {
            PasswordEncriptor encryptor = new();
            encryptor.CreateHashAndSalt(newPassword, out byte[] newSalt, out byte[] newHash);
            userCread.PasswordHash = newHash;
            userCread.PasswordSalt = newSalt;
            userCread.OTP = string.Empty;
            userCread.OTPExpiry = null;
            return userCread;
        }
    }
}
