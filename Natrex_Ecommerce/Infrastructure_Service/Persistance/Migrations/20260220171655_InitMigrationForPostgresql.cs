using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure_Service.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrationForPostgresql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CloudPublicId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PriceTotal = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderStatus = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "boolean", nullable: false),
                    TotalAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    AmountPaid = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CloudPublicId = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IPAddress = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalViews = table.Column<int>(type: "integer", nullable: false),
                    AverageRating = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalReviews = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductViews",
                columns: table => new
                {
                    ProductViewId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IPAddress = table.Column<string>(type: "text", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViews", x => x.ProductViewId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvinceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "SellerPayouts",
                columns: table => new
                {
                    SellerPayoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    AmountToPay = table.Column<double>(type: "double precision", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PayOutDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerPayouts", x => x.SellerPayoutId);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShopId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreName = table.Column<string>(type: "text", nullable: false),
                    StoreDescription = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "ShopDetails",
                columns: table => new
                {
                    ShopDetailsId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDetails", x => x.ShopDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "UserCreadentials",
                columns: table => new
                {
                    CreadId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    OTP = table.Column<string>(type: "text", nullable: false),
                    OTPExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreadentials", x => x.CreadId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CloudPublicId = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.SessionId);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { new Guid("11c32a0f-2c35-4bed-944a-9b4834423514"), "Lahore", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("14ae1dbe-5538-48a4-8720-bf8627aaae62"), "Kamoke", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("18f837b7-8b36-4bfb-88dd-b933e153e145"), "Tando Allahyar", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("1dc110e3-7c9a-402a-b11a-5aef0ef63696"), "Nowshera", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("298c5cf0-ad10-4dca-8c57-49a8cd68dfa4"), "Mirpur", new Guid("2652700e-a4e6-4d85-97de-28a104caabde") },
                    { new Guid("2a8b9931-a32a-450f-8546-5a1dc0760195"), "Kohat", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("32034cbb-d260-41c4-b39a-0455fb5b7bda"), "Rawalpindi", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("32588e15-db93-4f19-b6dd-65d80caf810b"), "Jhang", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("336eb174-945c-4d13-b6d7-0dc8a7f8c428"), "Turbat", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("338d1125-136d-41d6-b171-f8e20555f901"), "Multan", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("402b4b9f-894d-4fbb-9bab-27f034f814ad"), "Faisalabad", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("414d1212-38ad-40b3-a2c1-cf2d78e84102"), "Gwadar", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("4592eac9-44b4-42a3-aa84-797802243054"), "Mirpur Khas", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("462a5a3b-5663-48e1-a171-2bfd5e5165a6"), "Tando Adam", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("4b79eb8e-b3d6-4d5e-b6b6-30960bfd1705"), "Hunza", new Guid("0ebeb3fe-742c-4c32-afb6-ee706b26fcd9") },
                    { new Guid("4d063868-59a2-4728-8b19-25bf97c96b6a"), "Gilgit", new Guid("0ebeb3fe-742c-4c32-afb6-ee706b26fcd9") },
                    { new Guid("4d450f55-b872-419e-86ad-67b9529a55ee"), "Abbottabad", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("4f322c4a-8818-4dbc-91ce-615d72271c90"), "Okara", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("5384e9bd-b1a1-48fb-a762-dec319f95b9d"), "Skardu", new Guid("0ebeb3fe-742c-4c32-afb6-ee706b26fcd9") },
                    { new Guid("569eb43d-d99f-442c-851e-f8afcc00b8ac"), "Jacobabad", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("5aed5695-35db-4615-8b4d-1d6ac392d54d"), "Islamabad", new Guid("b00ebfe6-ff2b-474c-a2a5-90a3ac8077cf") },
                    { new Guid("626922d0-9b48-42c6-a00a-16253850260e"), "Charsadda", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("63e715cb-7e89-40f4-a717-e1756933abe3"), "Rawalakot", new Guid("2652700e-a4e6-4d85-97de-28a104caabde") },
                    { new Guid("6d5aee9a-339c-4cc5-b0bd-66c57ff1de9e"), "Sheikhupura", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("7e3c34d3-a3f4-4af4-a64b-b232a35378cb"), "Dadu", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("7ef47141-9ffa-4996-a6e7-390572e80cc9"), "Loralai", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("819b29d3-9cf7-4783-99d3-9d12f525f266"), "Hub", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("8ae33231-8054-4385-9293-da05b23c0f8a"), "Nawabshah", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("91073ac3-82ff-431c-90a3-71eef030f0b7"), "Karachi", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("91385f60-8e52-413a-b16e-cca98adeeb7d"), "Dera Ismail Khan", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("92b1df1a-a012-4236-95cc-fb8e1fcbb36d"), "Mansehra", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("95aa8286-2a60-4697-a032-1823b5341aed"), "Sibi", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("9948c980-bbcf-49a3-a601-a3f36011af44"), "Mardan", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("997f5b82-6b94-42d7-992e-f4bd0da6a2a0"), "Sukkur", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("9f203761-9a8a-4efa-844a-dc96e37940dc"), "Badin", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("9fbc2de0-8290-49bf-92ce-d0769d8c6753"), "Bannu", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("a4f8ca06-b1e8-428b-8a62-f2efc4b0bef2"), "Kasur", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("a66671cf-3852-4e75-8433-6d84a13c8f1d"), "Quetta", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("aa9c8403-7d5e-48ee-9779-f995ee877ff8"), "Shikarpur", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("ad9359d0-0c4e-4d24-987e-e3c773823d2a"), "Larkana", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("ae6a33f6-2f45-42cb-af2b-e6d181bbffea"), "Bahawalpur", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("b4d4551b-82fd-427c-9e5d-659eae19d0cf"), "Chiniot", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("ba78eef6-fb33-4e1d-aa5e-dd662f5b2971"), "Muzaffarabad", new Guid("2652700e-a4e6-4d85-97de-28a104caabde") },
                    { new Guid("bb78a831-6e4f-46f4-b9dd-28026b2a1a3a"), "Hyderabad", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("bde3519b-c2dd-46d3-9a0b-5b1bc9b73997"), "Dera Ghazi Khan", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("c6b54f01-ea91-44e6-b3fe-6cd85eb512e1"), "Sahiwal", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("d0cbadcf-a7cf-44ea-90eb-d30a00448bfc"), "Mingora", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("d188f219-5336-45e1-bc0c-aaba9ce65d81"), "Gujranwala", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("e15b5409-d8ad-4ddb-8282-4afb191af1b7"), "Khairpur", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") },
                    { new Guid("e567ffc2-01a2-4bdc-8f2a-4dc594ae0e0b"), "Peshawar", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("e8a034ea-de40-418d-b43c-87ed7b966c54"), "Khuzdar", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("e9523429-a45e-400e-aec1-ba3873a9a81a"), "Chaman", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("eb050c4d-75cf-470f-b330-013be4eca2e6"), "Gujrat", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("eb5c991a-102d-43e4-a740-8e8b6a962ede"), "Sargodha", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("ee56c835-7c1a-4372-abf5-88a9c2799804"), "Hafizabad", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("f121ad28-472d-4018-9a4a-92f871f91f08"), "Swabi", new Guid("2f3545e6-6ded-49f8-b597-c2119122607c") },
                    { new Guid("f76b553e-4b0b-46e5-8749-710a5102c81a"), "Sadiqabad", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("f89e5994-abeb-47ad-9599-f95689920b8a"), "Sialkot", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("fe1b9b1e-183e-4bf6-8844-4c4682fc79e3"), "Zhob", new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7") },
                    { new Guid("ff630a76-c931-4bc4-bce5-a605b05652e3"), "Rahim Yar Khan", new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21") },
                    { new Guid("ff74b59c-960e-4e39-84b2-472897052201"), "Thatta", new Guid("047fed8b-d44a-428b-9e16-7777972e01f2") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("2f9abb81-f6ab-4507-8df5-f96a358edb51"), "Clothing" },
                    { new Guid("4dba96a4-6fea-47df-af3a-e37cdbf0d2e7"), "Electronics" },
                    { new Guid("a1c3e5b2-3f4d-4c6e-8b2a-9f7e5d6c4b3a"), "Books" },
                    { new Guid("b5e8f7c6-1d2a-4e3b-9c8d-7f6e5d4c3b2a"), "Home & Kitchen" },
                    { new Guid("c3d4e5f6-7a8b-9c0d-1e2f-3a4b5c6d7e8f"), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { new Guid("047fed8b-d44a-428b-9e16-7777972e01f2"), "Sindh" },
                    { new Guid("0ebeb3fe-742c-4c32-afb6-ee706b26fcd9"), "Gilgit-Baltistan" },
                    { new Guid("2652700e-a4e6-4d85-97de-28a104caabde"), "Azad Jammu & Kashmir" },
                    { new Guid("2f3545e6-6ded-49f8-b597-c2119122607c"), "Khyber Pakhtunkhwa" },
                    { new Guid("91755a1c-9c22-46d3-aed6-d40a3cce1c21"), "Punjab" },
                    { new Guid("b00ebfe6-ff2b-474c-a2a5-90a3ac8077cf"), "Islamabad Capital Territory" },
                    { new Guid("e4c46d9c-da92-43df-a374-b3b2b02da7b7"), "Balochistan" }
                });

            migrationBuilder.InsertData(
                table: "ShopDetails",
                columns: new[] { "ShopDetailsId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("044808fa-b50d-4158-87f1-1c366ade2fc4"), "Laptops & Computers" },
                    { new Guid("0797ea35-90ed-4cd2-8bfa-418b65fec051"), "Health & Household" },
                    { new Guid("1894c8ce-b6e3-41f7-90e5-bb7ed72d58b9"), "Mobiles & Tablets" },
                    { new Guid("1b43faa3-43b9-4b5c-b00a-df27f60e3548"), "Beauty & Personal Care" },
                    { new Guid("3218c802-d573-461a-a65b-9a5d0df6123e"), "Watches & Jewelry" },
                    { new Guid("400df0e2-af62-4f81-861c-7d27e1ad5dbe"), "Tools & Improvement" },
                    { new Guid("6f96c2f1-3c56-41fe-ad1e-0cf9ae562b8a"), "Toys & Games" },
                    { new Guid("702d36c2-f1c3-4f15-a2ac-d89b219b2c66"), "Books" },
                    { new Guid("7195ec03-cd19-4198-80ee-1f3a0219b3c8"), "Home & Kitchen" },
                    { new Guid("737eaf82-f95c-4fd2-b07b-48b73b34fa3e"), "Electronics" },
                    { new Guid("7ef2ec4a-7bba-4041-84c8-88ac50441fe5"), "Sports" },
                    { new Guid("ad7e8ada-c088-470b-854d-e7358017a683"), "Video Games" },
                    { new Guid("bebdcdbb-4f49-43ca-a386-8557122342bf"), "Clothing" },
                    { new Guid("c86da114-d7b8-48ec-870c-16e2ab0306ef"), "Groceries & Pet Supplies" },
                    { new Guid("e38e2e44-d181-424e-adbd-90f4d01bab6f"), "Automotive" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductViews");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "SellerPayouts");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "ShopDetails");

            migrationBuilder.DropTable(
                name: "UserCreadentials");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSessions");
        }
    }
}
