using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.UserManagmentModule;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCreadential> UserCreadentials { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
