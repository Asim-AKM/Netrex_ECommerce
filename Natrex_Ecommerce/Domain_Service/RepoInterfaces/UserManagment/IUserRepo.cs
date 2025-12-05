using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserRepo
    {
        Task<User?> GetUserByIdentifier(string userIdentifier);

    }
}
