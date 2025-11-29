using Domain_Service.Entities.UserModule.Roles;
using Domain_Service.Entities.UserModule.UserCredentials;
using Domain_Service.Entities.UserModule.Users;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserCreadential> UserCreads { get; }
        IRepository<UserRole> UserRoles { get; }
        Task<int> SaveChangesAsync();
    }
}
