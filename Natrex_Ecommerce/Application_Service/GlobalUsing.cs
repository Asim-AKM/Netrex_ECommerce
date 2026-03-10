global using Domain_Service.Enums;
global using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
global using Domain_Service.Entities.CartAndOrderModule;
global using Domain_Service.Entities.ProductAndCategoryModule;
global using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;
global using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
global using Application_Service.DTO_s.UserManagmentDto_s;
global using Domain_Service.Entities.UserManagmentModule;
global using Application_Service.DTO_s.PaymentAndPayoutDtos;
global using Domain_Service.Entities.SellerPaymentModule;
global using Domain_Service.Entities.PaymentAndPayout;
global using Application_Service.DTO_s.ProductDTOS;
global using Domain_Service.Entities.ProductManagmentModule;
global using Domain_Service.Entities.LocationModules;
global using Application_Service.DTO_s.SellerDtos;
global using Domain_Service.Entities.SellerModule;
global using Application_Service.DTO_s.ShopDetailsDtos;
global using Application_Service.Services.UserManagmentServices.Implementation;
global using Application_Service.DTO_s.UsersDto.Accounts;
global using Application_Service.DTO_s.UserManagmentDto_s.WishList;
global using Application_Service.Security.Jwt;
global using Application_Service.Services.CartAndOrderModuleServices.CartServices.Implementation;
global using Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface;
global using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Implementation;
global using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface;
global using Application_Service.Services.Implementation;
global using Application_Service.Services.Interface;
global using Application_Service.Services.PaymentAndPayoutServices.Implementation;
global using Application_Service.Services.PaymentAndPayoutServices.Interface;
global using Application_Service.Services.ProductManagementService.Implementation;
global using Application_Service.Services.ProductManagementService.Interfaces;
global using Application_Service.Services.SellerAndShopDetailsServices.Implementations;
global using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
global using Application_Service.Services.UserManagmentServices.Interface;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Application_Service.Common.APIResponses;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers;
global using Domain_Service.RepoInterfaces.UnitOfWork;
global using Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderItemMappers;
global using Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers;
global using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
global using Application_Service.Common.Mappers.ProductMapper;
global using Domain_Service.RepoInterfaces.Cloudinary;
global using Application_Service.Common.Mappers.ProductMapper.ProductViewAndReviewMappers;
global using Application_Service.Common.Mappers.SellerAndShopDetailsMapper.SellerDtos;
global using Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto;
global using Application_Service.Common.Mappers.UserManagmentMapppers;
global using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
global using Domain_Service.RepoInterfaces.Email;
global using Microsoft.Extensions.Logging;
global using System.Security.Cryptography;
global using Microsoft.AspNetCore.Http;
global using Microsoft.EntityFrameworkCore;








