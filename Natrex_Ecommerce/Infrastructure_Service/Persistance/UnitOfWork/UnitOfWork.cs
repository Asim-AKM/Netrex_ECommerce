using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Entities.LocationModules;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Infrastructure_Service.Persistance.Repositories.ProductManagement;
using Infrastructure_Service.Persistance.Repositories.UserCreadentials;
using Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s;
using Infrastructure_Service.Persistance.Repositories.UserRoles;
using Infrastructure_Service.Persistance.Repositories.Users;

namespace Infrastructure_Service.Persistance.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IRepository<User> Users => new Repository<User>(_context);
        public IRepository<UserCreadential> UserCreads => new Repository<UserCreadential>(_context);
        public IRepository<UserRole> UserRoles => new Repository<UserRole>(_context);
        public IRepository<Invoice> Invoices => new Repository<Invoice>(_context);

        public IRepository<Product> Products => new Repository<Product>(_context);
        public IProductRepo ProductsRepository => new ProductRepo(_context);

        public IRepository<ProductImage> ProductImages => new Repository<ProductImage>(_context);
        public IProductImageRepo ProductImageRepository => new ProductImageRepo(_context);

        public IRepository<Seller> Sellers => new Repository<Seller>(_context);
        /// <summary>
        /// Gets the repository for managing <see cref="PaymentDetail"/> entities.
        /// </summary>
        public IRepository<PaymentDetail> PaymentDetails => new Repository<PaymentDetail>(_context);
        public IUserRepo UserRepository => new UserRepo(_context);
        public IUserRoleRepo UserRoleRepository => new UserRoleRepo(_context);
        public IUserCreadentialRepo UserCreadRepository => new UserCreadentialRepo(_context);


        public IRepository<Customer> Customers => new Repository<Customer>(_context);

        public ICustomerRepo CustomerRepository => new CustomerRepo(_context);

        public IRepository<CartItem> CartItems => new Repository<CartItem>(_context);

        public IRepository<Cart> Carts => new Repository<Cart>(_context);

        public IRepository<Order> Orders => new Repository<Order>(_context);

        public IRepository<OrderItem> OrderItems => new Repository<OrderItem>(_context);

        public IRepository<Province> Provinces => new Repository<Province>(_context);

        public IRepository<City> Cities => new Repository<City>(_context);

        public IRepository<ProductReview> ProductReview => new Repository<ProductReview>(_context);

        public IRepository<ProductView> ProductView => new Repository<ProductView>(_context);
        public IRepository<UserSession> UserSessions => new Repository<UserSession>(_context);
        public IUserSessionRepo UserSessionRepository => new UserSessionRepo(_context);

        public IWishListItemRepo WishListItemRepository => new WishListItemRepo(_context);

        public IRepository<WishListItem> WishListItems => new Repository<WishListItem>(_context);

        public IRepository<WishList> WishLists => new Repository<WishList>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
