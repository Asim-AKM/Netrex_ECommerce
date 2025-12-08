using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.Implementation;
using Application_Service.Services.Interface;
using Application_Service.Services.ProductManagementService.Implementation;
using Application_Service.Services.ProductManagementService.Interfaces;
using Application_Service.Services.UserManagmentServices.Implementation;
using Application_Service.Services.UserManagmentServices.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Service.DI.DIServices
{
    public static class ApplicationDIConfigration
    {
        public static IServiceCollection ApplicationServiceDIConfigrations(this IServiceCollection services) => services

                            .AddScoped<IPasswordEncriptor, PasswordEncriptor>()
                          .AddScoped<IUserAccountService, UserAccountService>()
                    .AddValidatorsFromAssemblyContaining<UserRegisterDto>()
                    .AddFluentValidationAutoValidation()
                   .AddScoped<IInvoiceManager, InvoiceManager>()
                    .AddScoped<IProductServices, ProductManagement>();
    }
}
