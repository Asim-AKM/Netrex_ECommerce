using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure_Service.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddShopCategorySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("044808fa-b50d-4158-87f1-1c366ade2fc4"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("0797ea35-90ed-4cd2-8bfa-418b65fec051"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("1894c8ce-b6e3-41f7-90e5-bb7ed72d58b9"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("1b43faa3-43b9-4b5c-b00a-df27f60e3548"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("3218c802-d573-461a-a65b-9a5d0df6123e"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("400df0e2-af62-4f81-861c-7d27e1ad5dbe"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("6f96c2f1-3c56-41fe-ad1e-0cf9ae562b8a"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("702d36c2-f1c3-4f15-a2ac-d89b219b2c66"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("7195ec03-cd19-4198-80ee-1f3a0219b3c8"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("737eaf82-f95c-4fd2-b07b-48b73b34fa3e"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("7ef2ec4a-7bba-4041-84c8-88ac50441fe5"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("ad7e8ada-c088-470b-854d-e7358017a683"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("bebdcdbb-4f49-43ca-a386-8557122342bf"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("c86da114-d7b8-48ec-870c-16e2ab0306ef"));

            migrationBuilder.DeleteData(
                table: "ShopDetails",
                keyColumn: "ShopDetailsId",
                keyValue: new Guid("e38e2e44-d181-424e-adbd-90f4d01bab6f"));
        }
    }
}
