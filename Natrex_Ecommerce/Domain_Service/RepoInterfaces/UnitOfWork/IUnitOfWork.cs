using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UserManagment;

namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    /// <summary>
    /// Represents the Unit of Work pattern, which coordinates  
    /// multiple repository operations under a single database transaction.
    /// </summary>
    /// <remarks>
    /// The Unit of Work ensures:
    /// <list type="bullet">
    ///     <item><description>All repository changes are saved in a controlled, atomic manner.</description></item>
    ///     <item><description>Prevents partial updates by committing or rolling back as one unit.</description></item>
    ///     <item><description>Promotes clean architecture by abstracting data access dependencies.</description></item>
    /// </list>
    /// This interface centralizes all repositories so application services 
    /// can access them through a single point.
    /// </remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository responsible for performing CRUD operations
        /// on <see cref="User"/> entities.
        /// </summary>
        IRepository<User> Users { get; }

        /// <summary>
        /// Gets the repository that manages data operations
        /// for <see cref="UserCreadential"/> entities.
        /// </summary>
        IRepository<UserCreadential> UserCreads { get; }

        /// <summary>
        /// Gets the repository for handling role-related operations
        /// associated with <see cref="UserRole"/>.
        /// </summary>
        IRepository<UserRole> UserRoles { get; }
        IUserRepo UserRepository { get; }
        IUserCreadentialRepo UserCreadRepository { get; }
        IUserRoleRepo UserRoleRepository { get; }
        ICustomerRepo CustomerRepository { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Product> Products { get; }
        IRepository<Seller> Sellers { get; }
        IRepository<ProductImage> ProductImages { get; }
        IRepository<Customer> Customers { get; }
       

        /// <summary>
        /// Gets the repository for processing and retrieving 
        /// <see cref="PaymentDetail"/> records.
        /// </summary>
        IRepository<PaymentDetail> PaymentDetails { get; }

        /// <summary>
        /// Saves all pending changes made through the repositories 
        /// into the database.
        /// </summary>
        /// <returns>
        /// Returns the number of affected rows written to the database.
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}


