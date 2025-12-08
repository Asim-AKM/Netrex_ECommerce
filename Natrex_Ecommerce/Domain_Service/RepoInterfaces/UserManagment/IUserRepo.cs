using Domain_Service.Entities.UserManagmentModule;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllUser();
        Task<User?> CheckEmail(string email);

    }
}
