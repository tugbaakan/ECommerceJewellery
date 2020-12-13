using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CartDuzenlendi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Products_productId",
                table: "Carties");

            migrationBuilder.DropIndex(
                name: "IX_Carties_productId",
                table: "Carties");

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Carties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Carties",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Carties_productId",
                table: "Carties",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Products_productId",
                table: "Carties",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
