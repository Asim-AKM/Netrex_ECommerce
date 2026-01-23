using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Entities.LocationModules;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Entities.SellerModule;
using Domain_Service.Entities.SellerPaymentModule;
using Domain_Service.Entities.UserManagmentModule;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<ShopDetail> ShopDetails {  get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
       

        public DbSet<UserCreadential> UserCreadentials { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<SellerPayout> SellerPayouts { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            #region Product Categories Seeding

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

            #endregion

            #region Provinces Seeding

            var punjabId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var sindhId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var kpkId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var balochId = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var gbId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var ajkId = Guid.Parse("66666666-6666-6666-6666-666666666666");
            var ictId = Guid.Parse("77777777-7777-7777-7777-777777777777");

            modelBuilder.Entity<Province>().HasData(
                new Province { ProvinceId = punjabId, ProvinceName = "Punjab" },
                new Province { ProvinceId = sindhId, ProvinceName = "Sindh" },
                new Province { ProvinceId = kpkId, ProvinceName = "Khyber Pakhtunkhwa" },
                new Province { ProvinceId = balochId, ProvinceName = "Balochistan" },
                new Province { ProvinceId = gbId, ProvinceName = "Gilgit-Baltistan" },
                new Province { ProvinceId = ajkId, ProvinceName = "Azad Jammu & Kashmir" },
                new Province { ProvinceId = ictId, ProvinceName = "Islamabad Capital Territory" }
            );

            #endregion

            #region Cities Seeding
            modelBuilder.Entity<City>().HasData(
                // --- PUNJAB (Prefix: aaaaaaaa) ---
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000001"), CityName = "Lahore", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000002"), CityName = "Faisalabad", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000003"), CityName = "Rawalpindi", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000004"), CityName = "Gujranwala", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000005"), CityName = "Multan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000006"), CityName = "Sargodha", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000007"), CityName = "Sialkot", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000008"), CityName = "Bahawalpur", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000009"), CityName = "Jhang", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000010"), CityName = "Sheikhupura", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000011"), CityName = "Gujrat", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000012"), CityName = "Sahiwal", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000013"), CityName = "Rahim Yar Khan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000014"), CityName = "Kasur", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000015"), CityName = "Okara", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000016"), CityName = "Dera Ghazi Khan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000017"), CityName = "Chiniot", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000018"), CityName = "Kamoke", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000019"), CityName = "Hafizabad", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("aaaaaaaa-1111-0000-0000-000000000020"), CityName = "Sadiqabad", ProvinceId = punjabId },

                // --- SINDH (Prefix: bbbbbbbb) ---
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000001"), CityName = "Karachi", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000002"), CityName = "Hyderabad", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000003"), CityName = "Sukkur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000004"), CityName = "Larkana", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000005"), CityName = "Nawabshah", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000006"), CityName = "Mirpur Khas", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000007"), CityName = "Jacobabad", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000008"), CityName = "Shikarpur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000009"), CityName = "Khairpur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000010"), CityName = "Dadu", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000011"), CityName = "Tando Adam", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000012"), CityName = "Tando Allahyar", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000013"), CityName = "Badin", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bbbbbbbb-2222-0000-0000-000000000014"), CityName = "Thatta", ProvinceId = sindhId },

                // --- KPK (Prefix: cccccccc) ---
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000001"), CityName = "Peshawar", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000002"), CityName = "Mardan", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000003"), CityName = "Mingora", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000004"), CityName = "Kohat", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000005"), CityName = "Abbottabad", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000006"), CityName = "Mansehra", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000007"), CityName = "Nowshera", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000008"), CityName = "Dera Ismail Khan", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000009"), CityName = "Swabi", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000010"), CityName = "Charsadda", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("cccccccc-3333-0000-0000-000000000011"), CityName = "Bannu", ProvinceId = kpkId },

                // --- BALOCHISTAN (Prefix: dddddddd) ---
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000001"), CityName = "Quetta", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000002"), CityName = "Turbat", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000003"), CityName = "Khuzdar", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000004"), CityName = "Hub", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000005"), CityName = "Chaman", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000006"), CityName = "Gwadar", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000007"), CityName = "Sibi", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000008"), CityName = "Zhob", ProvinceId = balochId },
                new City { CityId = Guid.Parse("dddddddd-4444-0000-0000-000000000009"), CityName = "Loralai", ProvinceId = balochId },

                // --- TERRITORIES (ICT, GB, AJK) ---
                new City { CityId = Guid.Parse("77777777-7777-0000-0000-000000000001"), CityName = "Islamabad", ProvinceId = ictId },
                new City { CityId = Guid.Parse("66666666-6666-0000-0000-000000000001"), CityName = "Muzaffarabad", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("66666666-6666-0000-0000-000000000002"), CityName = "Mirpur", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("66666666-6666-0000-0000-000000000003"), CityName = "Rawalakot", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("55555555-5555-0000-0000-000000000001"), CityName = "Gilgit", ProvinceId = gbId },
                new City { CityId = Guid.Parse("55555555-5555-0000-0000-000000000002"), CityName = "Skardu", ProvinceId = gbId },
                new City { CityId = Guid.Parse("55555555-5555-0000-0000-000000000003"), CityName = "Hunza", ProvinceId = gbId }
            );
            #endregion
        }


    }
}
