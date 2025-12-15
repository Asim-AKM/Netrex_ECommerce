using Application_Service.DI.DIServices; 
using Infrastructure_Service.DI.Repositories_DI;
using System.Reflection;

namespace APIGateway_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Application Service DI Configurations
            builder.Services.ApplicationServiceDIConfigrations();
            builder.Services.AddAppModelValidations();
           
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();

                // Application Service DI Configurations
                builder.Services.ApplicationServiceDIConfigrations();

                // Infrastructure Service DI Configurations 
                builder.Services.InfrastructureDIConfig(builder.Configuration);

                // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
                builder.Services.AddOpenApi();
                builder.Services.AddSwaggerGen();
                var app = builder.Build();

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

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
        }
    }
}
