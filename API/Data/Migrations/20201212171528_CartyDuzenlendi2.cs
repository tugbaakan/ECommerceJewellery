using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CartyDuzenlendi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Carts_cartId",
                table: "Carties");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Carties",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Carties",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Carties",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_cartId",
                table: "Carties",
                newName: "IX_Carties_CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Carties",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Carties",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carties",
                newName: "cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_CartId",
                table: "Carties",
                newName: "IX_Carties_cartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Carts_cartId",
                table: "Carties",
                column: "cartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
