using Application_Service.Services.Implementation;
using Application_Service.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Service.DI.DIServices
{
    public static class ApplicationDIConfigration
    {
        public static IServiceCollection ApplicationServiceDIConfigrations(this IServiceCollection services)
        {
            services.AddScoped<IPasswordEncriptor, PasswordEncriptor>()
                          .AddScoped<IUserAccountService, UserAccountService>();

            return services;    
        }
                        
    }
}
