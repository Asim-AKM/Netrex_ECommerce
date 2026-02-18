using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface IUserSessionRepo
    {
        Task<UserSession?> GetSessionByRefreshToken(string refreshToken);
        Task<UserSession?> GetSessionByFK(Guid userId);
    }
}
