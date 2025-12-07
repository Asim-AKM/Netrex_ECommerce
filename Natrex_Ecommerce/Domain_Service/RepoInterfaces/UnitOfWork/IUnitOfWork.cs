using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;

namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserCreadential> UserCreads { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Seller> Seller {  get; }
        Task<int> SaveChangesAsync();
    }
}
