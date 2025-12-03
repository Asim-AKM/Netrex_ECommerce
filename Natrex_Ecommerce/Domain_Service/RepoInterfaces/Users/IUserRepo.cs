using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.Users
{
    public interface IUserRepo
    {
        Task UserRegistration(User user);

    }
}
