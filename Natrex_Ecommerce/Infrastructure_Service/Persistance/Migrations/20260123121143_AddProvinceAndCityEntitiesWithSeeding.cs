using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure_Service.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddProvinceAndCityEntitiesWithSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "ProvinceId" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-0000-0000-000000000001"), "Gilgit", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("55555555-5555-0000-0000-000000000002"), "Skardu", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("55555555-5555-0000-0000-000000000003"), "Hunza", new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("66666666-6666-0000-0000-000000000001"), "Muzaffarabad", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("66666666-6666-0000-0000-000000000002"), "Mirpur", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("66666666-6666-0000-0000-000000000003"), "Rawalakot", new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("77777777-7777-0000-0000-000000000001"), "Islamabad", new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000001"), "Lahore", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000002"), "Faisalabad", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000003"), "Rawalpindi", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000004"), "Gujranwala", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000005"), "Multan", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000006"), "Sargodha", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000007"), "Sialkot", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000008"), "Bahawalpur", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000009"), "Jhang", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000010"), "Sheikhupura", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000011"), "Gujrat", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000012"), "Sahiwal", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000013"), "Rahim Yar Khan", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000014"), "Kasur", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000015"), "Okara", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000016"), "Dera Ghazi Khan", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000017"), "Chiniot", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000018"), "Kamoke", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000019"), "Hafizabad", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("aaaaaaaa-1111-0000-0000-000000000020"), "Sadiqabad", new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000001"), "Karachi", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000002"), "Hyderabad", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000003"), "Sukkur", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000004"), "Larkana", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000005"), "Nawabshah", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000006"), "Mirpur Khas", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000007"), "Jacobabad", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000008"), "Shikarpur", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000009"), "Khairpur", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000010"), "Dadu", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000011"), "Tando Adam", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000012"), "Tando Allahyar", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000013"), "Badin", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-2222-0000-0000-000000000014"), "Thatta", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("cccccccc-3333-0000-0000-000000000001"), "Peshawar", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000002"), "Mardan", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000003"), "Mingora", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000004"), "Kohat", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000005"), "Abbottabad", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000006"), "Mansehra", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000007"), "Nowshera", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000008"), "Dera Ismail Khan", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000009"), "Swabi", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000010"), "Charsadda", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-3333-0000-0000-000000000011"), "Bannu", new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("dddddddd-4444-0000-0000-000000000001"), "Quetta", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000002"), "Turbat", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000003"), "Khuzdar", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000004"), "Hub", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000005"), "Chaman", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000006"), "Gwadar", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000007"), "Sibi", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000008"), "Zhob", new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("dddddddd-4444-0000-0000-000000000009"), "Loralai", new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "ProvinceName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Punjab" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Sindh" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Khyber Pakhtunkhwa" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Balochistan" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Gilgit-Baltistan" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Azad Jammu & Kashmir" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Islamabad Capital Territory" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
