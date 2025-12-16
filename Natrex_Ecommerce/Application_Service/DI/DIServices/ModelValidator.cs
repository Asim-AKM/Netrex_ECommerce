using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UsersDto.Accounts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Service.DI.DIServices
{
    public static class ModelValidator
    {
        public static IServiceCollection AddAppModelValidations(
            this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssemblyContaining<CreateUserDto>()
                .AddFluentValidationAutoValidation();

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var errors = context.ModelState
                            .Where(x => x.Value.Errors.Count > 0)
                            .Select(x => new
                            {
                                Field = x.Key,
                                Errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                            })
                            .ToList();

                        return new BadRequestObjectResult(
                            ApiResponse<object>.Fail(
                                errors,
                                "Validation Errors"
                            )
                        );
                    };
                });

            return services;
        }
    }

}
