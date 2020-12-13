using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CartyDuzenlendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Carties",
                newName: "cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_CartId",
                table: "Carties",
                newName: "IX_Carties_cartId");

            migrationBuilder.AlterColumn<int>(
                name: "cartId",
                table: "Carties",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Carts_cartId",
                table: "Carties",
                column: "cartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carties_Carts_cartId",
                table: "Carties");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Carties",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Carties_cartId",
                table: "Carties",
                newName: "IX_Carties_CartId");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Carties",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Carties_Carts_CartId",
                table: "Carties",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
