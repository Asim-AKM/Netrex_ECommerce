using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace APIGateway_Service.Middlewares
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                logger.LogInformation("Database migration completed successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while applying migrations.");
                throw;
            }
        }
    }
}
