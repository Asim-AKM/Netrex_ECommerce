using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;

namespace Infrastructure_Service.Persistance.UnitOfWork
{
    /// <summary>
    /// Implements the Unit of Work pattern to coordinate repository operations
    /// and ensure that all database changes are committed as a single transaction.
    /// </summary>
    /// <remarks>
    /// This class centralizes access to all repositories and 
    /// manages the lifetime of <see cref="ApplicationDbContext"/>.
    /// <para>
    /// Every service that interacts with the database should use 
    /// <see cref="IUnitOfWork"/> to maintain clean architecture, 
    /// testability, and consistent data operations.
    /// </para>
    /// </remarks>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class
        /// using the provided database context.
        /// </summary>
        /// <param name="dbContext">The Entity Framework database context.</param>
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Gets the repository for performing CRUD operations on <see cref="User"/> entities.
        /// </summary>
        public IRepository<User> Users => new Repository<User>(_context);

        /// <summary>
        /// Gets the repository for handling <see cref="UserCreadential"/> entities.
        /// </summary>
        public IRepository<UserCreadential> UserCreads => new Repository<UserCreadential>(_context);

        /// <summary>
        /// Gets the repository for accessing and modifying <see cref="UserRole"/> records.
        /// </summary>
        public IRepository<UserRole> UserRoles => new Repository<UserRole>(_context);

        /// <summary>
        /// Gets the repository for performing CRUD operations on <see cref="Invoice"/> entities.
        /// </summary>
        public IRepository<Invoice> Invoices => new Repository<Invoice>(_context);

        /// <summary>
        /// Gets the repository for managing <see cref="PaymentDetail"/> entities.
        /// </summary>
        public IRepository<PaymentDetail> PaymentDetails => new Repository<PaymentDetail>(_context);

        /// <summary>
        /// Saves all pending changes to the database.
        /// </summary>
        /// <returns>
        /// Returns the number of state entries written to the database.
        /// </returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
