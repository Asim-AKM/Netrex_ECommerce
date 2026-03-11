using APIGateway_Service.DIs;
using APIGateway_Service.Middlewares;
using Application_Service.DI.DIServices;
using Infrastructure_Service.DI.Repositories_DI;
using Serilog;

namespace APIGateway_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

      
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowNetrexUI", policy =>
                {
                    policy.WithOrigins("https://localhost:7169")  
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddAppModelValidations();
            builder.Services.AddControllers();

          
            builder.Services.ApplicationServiceDIConfigrations(builder.Configuration);           
            builder.Services.InfrastructureDIConfig(builder.Configuration);

            builder.Services.AddOpenApi();
            builder.Services.AddJwtValidation(builder.Configuration);
           
            builder.Services.AddApiVersioningConfiguration();
            builder.Services.AddSwaggerConfiguration();

            builder.Services.AddRateLimiter(RateLimitingMiddleware.GetGlobalRateLimiter());
            builder.Host.AddSerilog(builder.Configuration);

            var app = builder.Build();
            app.ApplyMigrations();
            app.UseRateLimiter();
            app.UseCors("AllowNetrexUI");
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MyMiddleware();
            app.MapControllers();

            try
            {
                Log.Information("Netrex API Starting...");
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Netrex API Failed to Start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}