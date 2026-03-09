namespace Infrastructure_Service.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // User Management
        public IUserRepo UserRepo { get; }
        public IUserRoleRepo UserRoleRepo { get; }
        public IUserCreadentialRepo UserCreadRepo { get; }
        public IUserSessionRepo UserSessionRepo { get; }
        public ICustomerRepo CustomerRepo { get; }

        // Seller
        public ISellerRepository SellerRepo { get; }
        public IShopDetailsRepository ShopDetailsRepo { get; }

        // Product
        public IProductRepo ProductRepo { get; }
        public IProductImageRepo ProductImageRepo { get; }
        public IProductCategories ProductCategoryRepo { get; }
        public IProductRankingRepo ProductRankingRepo { get; }

        // Cart & Order
        public ICartRepo CartRepo { get; }
        public ICartItemRepo CartItemRepo { get; }
        public IOrderRepo OrderRepo { get; }
        public IOrderItemRepo OrderItemRepo { get; }

        // Payment
        public IInvoiceRepo InvoiceRepo { get; }
        public IPaymentDetailRepo PaymentDetailRepo { get; }
        public ISellerPayoutRepo SellerPayoutRepo { get; }

        // Wishlist
        public IWishListItemRepo WishListItemRepo { get; }
        public IRepository<WishList> WishLists { get; }

        // Location
        public IRepository<Province> Provinces { get; }
        public IRepository<City> Cities { get; }

        // Product Extra
        public IRepository<ProductReview> ProductReviews { get; }
        public IRepository<ProductView> ProductViews { get; }

        // Sessions
        public IRepository<UserSession> UserSessions { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            // User Management
            IUserRepo userRepo,
            IUserRoleRepo userRoleRepo,
            IUserCreadentialRepo userCreadRepo,
            IUserSessionRepo userSessionRepo,
            ICustomerRepo customerRepo,
            // Seller
            ISellerRepository sellerRepo,
            IShopDetailsRepository shopDetailsRepo,
            // Product
            IProductRepo productRepo,
            IProductImageRepo productImageRepo,
            IProductCategories productCategoryRepo,
            IProductRankingRepo productRankingRepo,
            // Cart & Order
            ICartRepo cartRepo,
            ICartItemRepo cartItemRepo,
            IOrderRepo orderRepo,
            IOrderItemRepo orderItemRepo,
            // Payment
            IInvoiceRepo invoiceRepo,
            IPaymentDetailRepo paymentDetailRepo,
            ISellerPayoutRepo sellerPayoutRepo,
            // Wishlist
            IWishListItemRepo wishListItemRepo,
            IRepository<WishList> wishLists,
            // Location
            IRepository<Province> provinces,
            IRepository<City> cities,
            // Product Extra
            IRepository<ProductReview> productReviews,
            IRepository<ProductView> productViews,
            // Sessions
            IRepository<UserSession> userSessions
        )
        {
            _context = context;

            UserRepo = userRepo;
            UserRoleRepo = userRoleRepo;
            UserCreadRepo = userCreadRepo;
            UserSessionRepo = userSessionRepo;
            CustomerRepo = customerRepo;

            SellerRepo = sellerRepo;
            ShopDetailsRepo = shopDetailsRepo;

            ProductRepo = productRepo;
            ProductImageRepo = productImageRepo;
            ProductCategoryRepo = productCategoryRepo;
            ProductRankingRepo = productRankingRepo;

            CartRepo = cartRepo;
            CartItemRepo = cartItemRepo;
            OrderRepo = orderRepo;
            OrderItemRepo = orderItemRepo;

            InvoiceRepo = invoiceRepo;
            PaymentDetailRepo = paymentDetailRepo;
            SellerPayoutRepo = sellerPayoutRepo;

            WishListItemRepo = wishListItemRepo;
            WishLists = wishLists;

            Provinces = provinces;
            Cities = cities;

            ProductReviews = productReviews;
            ProductViews = productViews;

            UserSessions = userSessions;
        }

        /// <summary>
        /// Commits all pending changes to the database.
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Executes multiple repository operations within a single transaction.
        /// </summary>
        public async Task ExecuteInTransactionAsync(Func<Task> operations)
        {
            if (operations == null) throw new ArgumentNullException(nameof(operations));

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await operations();
                await SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Disposes the DbContext and releases database connections.
        /// </summary>
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}