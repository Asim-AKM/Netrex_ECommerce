namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserRepo
    {
        Task<User?> GetUserByIdentifier(string userIdentifier);
        Task<List<User>> GetAllUsers();

    }
}
