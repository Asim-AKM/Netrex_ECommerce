namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IPasswordEncriptor
    {
        Task<bool> VerifyPassword(string password, byte[] storesalt, byte[] storeHash);
        Task CreateHashAndSalt(string password, out byte[] salt, out byte[] hash);
    }
}
