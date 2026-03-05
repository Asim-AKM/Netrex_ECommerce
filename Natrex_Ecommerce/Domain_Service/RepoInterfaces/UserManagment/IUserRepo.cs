namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserRepo : IRepository<User>
    {
        Task<User?> GetUserByIdentifier(string userIdentifier);
        Task<List<User>> GetAllUsers();

    }
}
