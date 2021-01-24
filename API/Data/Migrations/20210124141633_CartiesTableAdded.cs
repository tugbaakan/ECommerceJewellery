using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CartiesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties");

            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Products_ProductId",
                table: "Carties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carties",
                table: "Carties");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameTable(
                name: "Carties",
                newName: "Carty");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_ProductId",
                table: "Carty",
                newName: "IX_Carty_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_CartId",
                table: "Carty",
                newName: "IX_Carty_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carty",
                table: "Carty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carty_Cart_CartId",
                table: "Carty",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carty_Products_ProductId",
                table: "Carty",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carty_Cart_CartId",
                table: "Carty");

            migrationBuilder.DropForeignKey(
                name: "FK_Carty_Products_ProductId",
                table: "Carty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carty",
                table: "Carty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Carty",
                newName: "Carties");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Carty_ProductId",
                table: "Carties",
                newName: "IX_Carties_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Carty_CartId",
                table: "Carties",
                newName: "IX_Carties_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carties",
                table: "Carties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Products_ProductId",
                table: "Carties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
