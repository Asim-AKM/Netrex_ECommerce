using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure_Service.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_shopDetails",
                table: "shopDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carts",
                table: "carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems");

            migrationBuilder.RenameTable(
                name: "shopDetails",
                newName: "ShopDetails");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "carts",
                newName: "Carts");

            migrationBuilder.RenameTable(
                name: "cartItems",
                newName: "CartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopDetails",
                table: "ShopDetails",
                column: "ShopDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "CartItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopDetails",
                table: "ShopDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "ShopDetails",
                newName: "shopDetails");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "orderItems");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "carts");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "cartItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopDetails",
                table: "shopDetails",
                column: "ShopDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "OrderItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carts",
                table: "carts",
                column: "CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cartItems",
                table: "cartItems",
                column: "CartItemId");
        }
    }
}
