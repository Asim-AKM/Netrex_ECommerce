using APIGateway_Service.Middlewares;
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
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty; // Swagger at root
                });
                app.MapOpenApi();
            }
            app.UseMiddleware<GlobalExceptionHandleMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("AllowNetrexUI");
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}
