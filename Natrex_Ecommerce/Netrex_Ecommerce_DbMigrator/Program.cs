using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Netrex_Ecommerce_DbMigrator
{
    internal class Program
    {
       public static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();
            MigrateDatabase(host);
            Console.WriteLine("Database migration completed successfully.");
        }



        public static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 config.SetBasePath(AppContext.BaseDirectory);
                 config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             })
             .ConfigureServices((hostContext, services) =>
             {
                 var configuration = hostContext.Configuration;

                 services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("NetrexConnectionString")));

                 services.AddLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                 });
             });

        private static void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var db = services.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}
