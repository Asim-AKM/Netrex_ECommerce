using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.UserManagmentModule;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    CategoryId = Guid.Parse("4dba96a4-6fea-47df-af3a-e37cdbf0d2e7"),
                    CategoryName = "Electronics"
                },
                new ProductCategory
                {
                    CategoryId = Guid.Parse("2f9abb81-f6ab-4507-8df5-f96a358edb51"),
                    CategoryName = "Clothing"
                },
                new ProductCategory
                {
                    CategoryId = Guid.Parse("a1c3e5b2-3f4d-4c6e-8b2a-9f7e5d6c4b3a"),
                    CategoryName = "Books"
                },
                new ProductCategory
                {
                    CategoryId = Guid.Parse("b5e8f7c6-1d2a-4e3b-9c8d-7f6e5d4c3b2a"),
                    CategoryName = "Home & Kitchen"
                },
                new ProductCategory
                {
                    CategoryId = Guid.Parse("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                    CategoryName = "Sports"
                }
            );
        }

        public DbSet<UserCreadential> UserCreadentials { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
