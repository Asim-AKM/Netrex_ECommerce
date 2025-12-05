using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Infrastructure_Service.Persistance.Repositories.PaymentAndPayout;

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

        IRepository<Invoice> IUnitOfWork.Invoices => new Repository<Invoice>(_context);

        public async Task<int> SaveChangesAsync()
        {
           return  await _context.SaveChangesAsync();
        }
    }
}
