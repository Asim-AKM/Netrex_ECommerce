using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.CartRepo;
using Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo;
using Infrastructure_Service.Persistance.Repositories.PaymentAndPayout;
using Infrastructure_Service.Persistance.Repositories.ProductManagement;
using Infrastructure_Service.Persistance.Repositories.SellerAndShopDetails;
using Infrastructure_Service.Persistance.Repositories.UserCreadentials;
using Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s;
using Infrastructure_Service.Persistance.Repositories.UserRoles;
using Infrastructure_Service.Persistance.Repositories.Users;
using Infrastructure_Service.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("NetrexConnectionString")))
                    .AddScoped<ICustomerRepo, CustomerRepo>()
                    .AddScoped<ICartRepo, CartRepo>()
                    .AddScoped<ICartItemRepo, CartItemRepo>()
                    .AddScoped<IOrderRepo, OrderRepo>()
                    .AddScoped<IOrderItemRepo, OrderItemRepo>()
                    .AddScoped<IPaymentDetailRepo, PaymentDetailRepo>()
                    .AddScoped<ISellerPayoutRepo, SellerPayoutRepo>();
                    .AddScoped<ISellerRepository, SellerRepository>()
                    .AddScoped<IShopDetailsRepository, ShopDetailsRepository>();


    }
}
