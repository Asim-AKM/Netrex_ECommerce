using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure_Service.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Configuration build karo - DONO files include karo
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../APIGateway_Service"))
                .AddJsonFile("appsettings.json", optional: true)           // 👈 Optional karo
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)  // 👈 Ye main hai
                .Build();

            // Connection string lo
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContextOptions banao
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString); // Jo DB use kar rahe ho

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}