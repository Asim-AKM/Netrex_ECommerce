using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Domain_Service.RepoInterfaces.UserManagment;

namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserCreadential> UserCreads { get; }
        IRepository<UserRole> UserRoles { get; }
        IUserRepo UserRepository { get; }
        IUserCreadentialRepo UserCreadRepository { get; }
        IRepository<Invoice> Invoices { get; }
        Task<int> SaveChangesAsync();
    }
}
