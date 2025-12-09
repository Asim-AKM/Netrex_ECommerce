using Application_Service.DI.DIServices; 
using Infrastructure_Service.DI.DIRepository;

namespace APIGateway_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Application Service DI Configurations
            builder.Services.ApplicationServiceDIConfigrations();

            // Infrastructure Service DI Configurations 
            builder.Services.InfrastuctureDIConfig(builder.Configuration);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
         
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
