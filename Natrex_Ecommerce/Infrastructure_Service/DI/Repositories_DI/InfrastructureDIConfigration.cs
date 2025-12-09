using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Domain_Service.RepoInterfaces.ProductRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Infrastructure_Service.Persistance.Repositories.PaymentAndPayout;
using Infrastructure_Service.Persistance.Repositories.ProductManagement;
using Infrastructure_Service.Persistance.Repositories.UserCreadentials;
using Infrastructure_Service.Persistance.Repositories.UserRoles;
using Infrastructure_Service.Persistance.Repositories.Users;
using Infrastructure_Service.Persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure_Service.DI.DIRepository
{
    public static class InfrastructureDIConfigration
    {
        public static IServiceCollection InfrastuctureDIConfig(this IServiceCollection services,IConfigurationManager configuration) => services
                    .AddScoped<IUserRepo, UserRepo>()
                    .AddScoped<IUserCreadentialRepo, UserCreadentialRepo>()
                    .AddScoped<IUserRoleRepo, UserRoleRepo>()
                    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IInvoiceRepo, InvoiceRepo>()
                    .AddScoped<IProductRepo, ProductRepo>()
                    .AddScoped<IProductImageRepo, ProductImageRepo>()
                    .AddScoped<IProductCategories, ProductCategoryRepo>();
                    .AddScoped<IInvoiceRepo,InvoiceRepo>()
                    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
