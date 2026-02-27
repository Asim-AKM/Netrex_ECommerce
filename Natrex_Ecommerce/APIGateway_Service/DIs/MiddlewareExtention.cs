using APIGateway_Service.Middlewares;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  APIGateway_Service.DIs
{
    public static class MiddlewareExtention
    {
        public static WebApplication MyMiddleware(this WebApplication app)
        { 
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            $"Netrex API {description.GroupName.ToUpperInvariant()}"
                        );
                    }
                    options.RoutePrefix = string.Empty; // Swagger at root
                });
                app.MapOpenApi();
            }
            app.UseMiddleware<GlobalExceptionHandleMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("AllowNetrexUI");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
