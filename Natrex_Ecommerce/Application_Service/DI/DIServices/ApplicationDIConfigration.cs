namespace Application_Service.DI.DIServices
{
    public static class ApplicationDIConfigration
    {
        public static IServiceCollection ApplicationServiceDIConfigrations(this IServiceCollection services, IConfiguration configuration) => services

                            .AddScoped<IPasswordEncriptor, PasswordEncriptor>()
                            .AddScoped<IInvoiceManager, InvoiceManager>()
                            .AddScoped<IPaymentDetailManager, PaymentDetailManager>()
                            .AddScoped<IProductManager, ProductManager>()
                            .AddScoped<IUserManager, UserManager>()
                            .AddScoped<IAuthenticationManager, AuthenticationManager>()
                            .Configure<JwtSettings>(configuration.GetSection("JwtSettings"))
                            .AddScoped<IJwtManager, JwtManager>()
                            .AddScoped<ISellerPayoutManager, SellerPayoutManager>()
                            .AddScoped<ISellerManager, SellerManager>()
                            .AddScoped<ICartItemManager, CartItemManager>()
                            .AddScoped<IShopDetailsManager, ShopDetailsManager>()
                            .AddScoped<IOrderManager, OrderManager>()
                            .AddScoped<IOrderItemManager, OrderItemManager>()
                            .AddScoped<IUserSessionManager, UserSessionManager>()
                            .AddScoped<ICustomerManager, CustomerManager>()
                            .AddScoped<IProductReviewManager, ProductReviewManager>()
                            .AddScoped<IProductRankingManager, ProductRankingManager>()
                            .AddScoped<IProductViewManager, ProductViewManager>()
                            .AddScoped<IProductRankingManager, ProductRankingManager>()
                            .AddScoped<IWishListManager, WishListManager>()
                            .AddScoped<IPaymentManager, PaymentManager>()
            .AddScoped<IAdminSellerService, AdminSellerService>();
    }
}
