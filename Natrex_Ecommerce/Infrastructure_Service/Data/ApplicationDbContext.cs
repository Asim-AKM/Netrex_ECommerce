using Domain_Service.Entities.UserManagmentModule;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

         public DbSet<User> Users { get; set; }
    }
}
