using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;

namespace Infrastructure_Service.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IRepository<User> Users =>  new Repository<User>(_context);
        public IRepository<UserCreadential> UserCreads => new Repository<UserCreadential>(_context);
        public IRepository<UserRole> UserRoles => new Repository<UserRole>(_context);

        public IRepository<Invoice> Invoices => new Repository<Invoice>(_context);

        public IRepository<Product> Products =>  new Repository<Product>(_context);

        public IRepository<ProductImage> ProductImages => new Repository<ProductImage>(_context);

        public IRepository<Seller> Sellers => new Repository<Seller>(_context);

        public async Task<int> SaveChangesAsync()
        {
           return  await _context.SaveChangesAsync();
        }
    }
}
