namespace Domain_Service.RepoInterfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // User Management
        IUserRepo UserRepo { get; }
        IUserRoleRepo UserRoleRepo { get; }
        IUserCreadentialRepo UserCreadRepo { get; }
        IUserSessionRepo UserSessionRepo { get; }
        ICustomerRepo CustomerRepo { get; }

        // Seller
        ISellerRepository SellerRepo { get; }
        IShopDetailsRepository ShopDetailsRepo { get; }

        // Product
        IProductRepo ProductRepo { get; }
        IProductImageRepo ProductImageRepo { get; }
        IProductCategories ProductCategoryRepo { get; }
        IProductRankingRepo ProductRankingRepo { get; }

        // Cart & Order
        ICartRepo CartRepo { get; }
        ICartItemRepo CartItemRepo { get; }
        IOrderRepo OrderRepo { get; }
        IOrderItemRepo OrderItemRepo { get; }

        // Payment
        IInvoiceRepo InvoiceRepo { get; }
        IPaymentDetailRepo PaymentDetailRepo { get; }
        ISellerPayoutRepo SellerPayoutRepo { get; }

        // Wishlist
        IWishListItemRepo WishListItemRepo { get; }
        IRepository<WishList> WishLists { get; }

        // Location
        IRepository<Province> Provinces { get; }
        IRepository<City> Cities { get; }

        // Product Extra
        IRepository<ProductReview> ProductReviews { get; }
        IRepository<ProductView> ProductViews { get; }

        // Sessions (generic + specific both kept)
        IRepository<UserSession> UserSessions { get; }

        /// <summary>
        /// Commits all pending changes to the database.
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Executes multiple repository operations within a single transaction.
        /// </summary>
        Task ExecuteInTransactionAsync(Func<Task> operations);
    }
}