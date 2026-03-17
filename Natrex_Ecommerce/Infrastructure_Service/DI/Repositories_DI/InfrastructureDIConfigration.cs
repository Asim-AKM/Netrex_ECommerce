using Application_Service.Services.ChatBotService.Interfaces;
using Domain_Service.RepoInterfaces.ChatBot;
using ECommerce.Infrastructure.Services;
using Infrastructure_Service.Persistance.Repositories.ChatBot;

namespace Infrastructure_Service.DI.Repositories_DI
{
    public static class InfrastructureDIConfigration
    {
        public static IServiceCollection InfrastructureDIConfig(this IServiceCollection services, IConfiguration configuration) => services
                    .AddScoped<IUserRepo, UserRepo>()
                    .AddScoped<IUserCreadentialRepo, UserCreadentialRepo>()
                    .AddScoped<IUserRoleRepo, UserRoleRepo>()
                    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IInvoiceRepo, InvoiceRepo>()
                    .AddScoped<IProductRepo, ProductRepo>()
                    .AddScoped<IProductImageRepo, ProductImageRepo>()
                    .AddScoped<IProductCategories, ProductCategoryRepo>()
                    .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("NetrexConnectionString")))
                    .AddScoped<ICustomerRepo, CustomerRepo>()
                    .AddScoped<ICartRepo, CartRepo>()
                    .AddScoped<ICartItemRepo, CartItemRepo>()
                    .AddScoped<IOrderRepo, OrderRepo>()
                    .AddScoped<IOrderItemRepo, OrderItemRepo>()
                    .AddScoped<IPaymentDetailRepo, PaymentDetailRepo>()
                    .AddScoped<ISellerPayoutRepo, SellerPayoutRepo>()
                    .AddScoped<ISellerRepository, SellerRepository>()
                    .AddScoped<IShopDetailsRepository, ShopDetailsRepository>()
                    .Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"))
                    .AddScoped<ICloudinaryManager, CloudinaryManager>()
                    .AddScoped<IUserSessionRepo, UserSessionRepo>()
                    .AddScoped<IEmailManager, EmailManager>()
                    .AddScoped<IProductRankingRepo, ProductRankingRepo>()
                    .AddScoped<IWishListItemRepo, WishListItemRepo>()
                    .AddScoped<IChatRepository, ChatRepository>()
                    .AddScoped<IAIService, GroqAIService>();
    }
}
