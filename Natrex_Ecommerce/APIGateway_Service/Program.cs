using Application_Service.DI.DIServices;
using Infrastructure_Service.DI.DIRepository;

namespace APIGateway_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Application Service DI Configurations
            builder.Services.ApplicationServiceDIConfigrations();
            builder.Services.AddAppModelValidations();

            // Infrastructure Service DI Configurations 
            builder.Services.InfrastuctureDIConfig(builder.Configuration);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
                app.UseSwagger();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
