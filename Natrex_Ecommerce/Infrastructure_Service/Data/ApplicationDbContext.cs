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
        public DbSet<ShopDetail> ShopDetails { get; set; }
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
        public DbSet<UserSession> UserSessions { get; set; }

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

            var punjabId = Guid.Parse("91755a1c-9c22-46d3-aed6-d40a3cce1c21");
            var sindhId = Guid.Parse("047fed8b-d44a-428b-9e16-7777972e01f2");
            var kpkId = Guid.Parse("2f3545e6-6ded-49f8-b597-c2119122607c");
            var balochId = Guid.Parse("e4c46d9c-da92-43df-a374-b3b2b02da7b7");
            var gbId = Guid.Parse("0ebeb3fe-742c-4c32-afb6-ee706b26fcd9");
            var ajkId = Guid.Parse("2652700e-a4e6-4d85-97de-28a104caabde");
            var ictId = Guid.Parse("b00ebfe6-ff2b-474c-a2a5-90a3ac8077cf");

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
                // --- PUNJAB ---
                new City { CityId = Guid.Parse("11c32a0f-2c35-4bed-944a-9b4834423514"), CityName = "Lahore", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("402b4b9f-894d-4fbb-9bab-27f034f814ad"), CityName = "Faisalabad", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("32034cbb-d260-41c4-b39a-0455fb5b7bda"), CityName = "Rawalpindi", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("d188f219-5336-45e1-bc0c-aaba9ce65d81"), CityName = "Gujranwala", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("338d1125-136d-41d6-b171-f8e20555f901"), CityName = "Multan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("eb5c991a-102d-43e4-a740-8e8b6a962ede"), CityName = "Sargodha", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("f89e5994-abeb-47ad-9599-f95689920b8a"), CityName = "Sialkot", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("ae6a33f6-2f45-42cb-af2b-e6d181bbffea"), CityName = "Bahawalpur", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("32588e15-db93-4f19-b6dd-65d80caf810b"), CityName = "Jhang", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("6d5aee9a-339c-4cc5-b0bd-66c57ff1de9e"), CityName = "Sheikhupura", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("eb050c4d-75cf-470f-b330-013be4eca2e6"), CityName = "Gujrat", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("c6b54f01-ea91-44e6-b3fe-6cd85eb512e1"), CityName = "Sahiwal", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("ff630a76-c931-4bc4-bce5-a605b05652e3"), CityName = "Rahim Yar Khan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("a4f8ca06-b1e8-428b-8a62-f2efc4b0bef2"), CityName = "Kasur", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("4f322c4a-8818-4dbc-91ce-615d72271c90"), CityName = "Okara", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("bde3519b-c2dd-46d3-9a0b-5b1bc9b73997"), CityName = "Dera Ghazi Khan", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("b4d4551b-82fd-427c-9e5d-659eae19d0cf"), CityName = "Chiniot", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("14ae1dbe-5538-48a4-8720-bf8627aaae62"), CityName = "Kamoke", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("ee56c835-7c1a-4372-abf5-88a9c2799804"), CityName = "Hafizabad", ProvinceId = punjabId },
                new City { CityId = Guid.Parse("f76b553e-4b0b-46e5-8749-710a5102c81a"), CityName = "Sadiqabad", ProvinceId = punjabId },

                // --- SINDH ---
                new City { CityId = Guid.Parse("91073ac3-82ff-431c-90a3-71eef030f0b7"), CityName = "Karachi", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("bb78a831-6e4f-46f4-b9dd-28026b2a1a3a"), CityName = "Hyderabad", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("997f5b82-6b94-42d7-992e-f4bd0da6a2a0"), CityName = "Sukkur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("ad9359d0-0c4e-4d24-987e-e3c773823d2a"), CityName = "Larkana", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("8ae33231-8054-4385-9293-da05b23c0f8a"), CityName = "Nawabshah", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("4592eac9-44b4-42a3-aa84-797802243054"), CityName = "Mirpur Khas", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("569eb43d-d99f-442c-851e-f8afcc00b8ac"), CityName = "Jacobabad", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("aa9c8403-7d5e-48ee-9779-f995ee877ff8"), CityName = "Shikarpur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("e15b5409-d8ad-4ddb-8282-4afb191af1b7"), CityName = "Khairpur", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("7e3c34d3-a3f4-4af4-a64b-b232a35378cb"), CityName = "Dadu", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("462a5a3b-5663-48e1-a171-2bfd5e5165a6"), CityName = "Tando Adam", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("18f837b7-8b36-4bfb-88dd-b933e153e145"), CityName = "Tando Allahyar", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("9f203761-9a8a-4efa-844a-dc96e37940dc"), CityName = "Badin", ProvinceId = sindhId },
                new City { CityId = Guid.Parse("ff74b59c-960e-4e39-84b2-472897052201"), CityName = "Thatta", ProvinceId = sindhId },

                // --- KPK ---
                new City { CityId = Guid.Parse("e567ffc2-01a2-4bdc-8f2a-4dc594ae0e0b"), CityName = "Peshawar", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("9948c980-bbcf-49a3-a601-a3f36011af44"), CityName = "Mardan", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("d0cbadcf-a7cf-44ea-90eb-d30a00448bfc"), CityName = "Mingora", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("2a8b9931-a32a-450f-8546-5a1dc0760195"), CityName = "Kohat", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("4d450f55-b872-419e-86ad-67b9529a55ee"), CityName = "Abbottabad", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("92b1df1a-a012-4236-95cc-fb8e1fcbb36d"), CityName = "Mansehra", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("1dc110e3-7c9a-402a-b11a-5aef0ef63696"), CityName = "Nowshera", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("91385f60-8e52-413a-b16e-cca98adeeb7d"), CityName = "Dera Ismail Khan", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("f121ad28-472d-4018-9a4a-92f871f91f08"), CityName = "Swabi", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("626922d0-9b48-42c6-a00a-16253850260e"), CityName = "Charsadda", ProvinceId = kpkId },
                new City { CityId = Guid.Parse("9fbc2de0-8290-49bf-92ce-d0769d8c6753"), CityName = "Bannu", ProvinceId = kpkId },

                // --- BALOCHISTAN ---
                new City { CityId = Guid.Parse("a66671cf-3852-4e75-8433-6d84a13c8f1d"), CityName = "Quetta", ProvinceId = balochId },
                new City { CityId = Guid.Parse("336eb174-945c-4d13-b6d7-0dc8a7f8c428"), CityName = "Turbat", ProvinceId = balochId },
                new City { CityId = Guid.Parse("e8a034ea-de40-418d-b43c-87ed7b966c54"), CityName = "Khuzdar", ProvinceId = balochId },
                new City { CityId = Guid.Parse("819b29d3-9cf7-4783-99d3-9d12f525f266"), CityName = "Hub", ProvinceId = balochId },
                new City { CityId = Guid.Parse("e9523429-a45e-400e-aec1-ba3873a9a81a"), CityName = "Chaman", ProvinceId = balochId },
                new City { CityId = Guid.Parse("414d1212-38ad-40b3-a2c1-cf2d78e84102"), CityName = "Gwadar", ProvinceId = balochId },
                new City { CityId = Guid.Parse("95aa8286-2a60-4697-a032-1823b5341aed"), CityName = "Sibi", ProvinceId = balochId },
                new City { CityId = Guid.Parse("fe1b9b1e-183e-4bf6-8844-4c4682fc79e3"), CityName = "Zhob", ProvinceId = balochId },
                new City { CityId = Guid.Parse("7ef47141-9ffa-4996-a6e7-390572e80cc9"), CityName = "Loralai", ProvinceId = balochId },

                // --- TERRITORIES (ICT, GB, AJK) ---
                new City { CityId = Guid.Parse("5aed5695-35db-4615-8b4d-1d6ac392d54d"), CityName = "Islamabad", ProvinceId = ictId },
                new City { CityId = Guid.Parse("ba78eef6-fb33-4e1d-aa5e-dd662f5b2971"), CityName = "Muzaffarabad", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("298c5cf0-ad10-4dca-8c57-49a8cd68dfa4"), CityName = "Mirpur", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("63e715cb-7e89-40f4-a717-e1756933abe3"), CityName = "Rawalakot", ProvinceId = ajkId },
                new City { CityId = Guid.Parse("4d063868-59a2-4728-8b19-25bf97c96b6a"), CityName = "Gilgit", ProvinceId = gbId },
                new City { CityId = Guid.Parse("5384e9bd-b1a1-48fb-a762-dec319f95b9d"), CityName = "Skardu", ProvinceId = gbId },
                new City { CityId = Guid.Parse("4b79eb8e-b3d6-4d5e-b6b6-30960bfd1705"), CityName = "Hunza", ProvinceId = gbId }

            );
            #endregion

            #region Shop Categories Seeding

            modelBuilder.Entity<ShopDetail>().HasData(
                new ShopDetail { ShopDetailsId = Guid.Parse("737eaf82-f95c-4fd2-b07b-48b73b34fa3e"), CategoryName = "Electronics" },
                new ShopDetail { ShopDetailsId = Guid.Parse("bebdcdbb-4f49-43ca-a386-8557122342bf"), CategoryName = "Clothing" },
                new ShopDetail { ShopDetailsId = Guid.Parse("702d36c2-f1c3-4f15-a2ac-d89b219b2c66"), CategoryName = "Books" },
                new ShopDetail { ShopDetailsId = Guid.Parse("7195ec03-cd19-4198-80ee-1f3a0219b3c8"), CategoryName = "Home & Kitchen" },
                new ShopDetail { ShopDetailsId = Guid.Parse("7ef2ec4a-7bba-4041-84c8-88ac50441fe5"), CategoryName = "Sports" },
                new ShopDetail { ShopDetailsId = Guid.Parse("1894c8ce-b6e3-41f7-90e5-bb7ed72d58b9"), CategoryName = "Mobiles & Tablets" },
                new ShopDetail { ShopDetailsId = Guid.Parse("044808fa-b50d-4158-87f1-1c366ade2fc4"), CategoryName = "Laptops & Computers" },
                new ShopDetail { ShopDetailsId = Guid.Parse("1b43faa3-43b9-4b5c-b00a-df27f60e3548"), CategoryName = "Beauty & Personal Care" },
                new ShopDetail { ShopDetailsId = Guid.Parse("6f96c2f1-3c56-41fe-ad1e-0cf9ae562b8a"), CategoryName = "Toys & Games" },
                new ShopDetail { ShopDetailsId = Guid.Parse("0797ea35-90ed-4cd2-8bfa-418b65fec051"), CategoryName = "Health & Household" },
                new ShopDetail { ShopDetailsId = Guid.Parse("e38e2e44-d181-424e-adbd-90f4d01bab6f"), CategoryName = "Automotive" },
                new ShopDetail { ShopDetailsId = Guid.Parse("c86da114-d7b8-48ec-870c-16e2ab0306ef"), CategoryName = "Groceries & Pet Supplies" },
                new ShopDetail { ShopDetailsId = Guid.Parse("400df0e2-af62-4f81-861c-7d27e1ad5dbe"), CategoryName = "Tools & Improvement" },
                new ShopDetail { ShopDetailsId = Guid.Parse("3218c802-d573-461a-a65b-9a5d0df6123e"), CategoryName = "Watches & Jewelry" },
                new ShopDetail { ShopDetailsId = Guid.Parse("ad7e8ada-c088-470b-854d-e7358017a683"), CategoryName = "Video Games" }
            );

            #endregion

        }


    }
}
