using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<UserCreadential> UserCreads { get; }
        IRepository<UserRole> UserRoles { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Product> Products { get; }
        IRepository<Seller> Sellers { get; }
        IRepository<ProductImage> ProductImages { get; }
       
        Task<int> SaveChangesAsync();
    }
}
