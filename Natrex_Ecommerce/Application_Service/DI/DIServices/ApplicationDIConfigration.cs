using Application_Service.DTO_s.UserManagmentDto_s;
﻿using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.DTO_s.Validators.UserMangement;
using Application_Service.Security.Jwt;
using Application_Service.Services.Implementation;
using Application_Service.Services.Interface;
using Application_Service.Services.PaymentAndPayoutServices.Implementation;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Application_Service.Services.ProductManagementService.Implementation;
using Application_Service.Services.ProductManagementService.Interfaces;
using Application_Service.Services.SellerAndShopDetailsServices.Implementations;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Application_Service.Services.UserManagmentServices.Implementation;
using Application_Service.Services.UserManagmentServices.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                             .AddScoped<ISellerManager, SellerManager>()
                            .AddScoped<IShopDetailsManager, ShopDetailsManager>();

    }
}
