namespace Application_Service.Services.UserManagmentServices.Implementation
{
    internal class PasswordEncriptor : IPasswordEncriptor
    {
        public Task CreateHashAndSalt(string password,out byte[] salt, out byte[] hash)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Task.CompletedTask;
        }

        public Task<bool> VerifyPassword(string password, byte[] storesalt, byte[] storeHash)
        {
            using var hmac = new HMACSHA512(storesalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Task.FromResult(computedHash.SequenceEqual(storeHash));
        }
    }
}
