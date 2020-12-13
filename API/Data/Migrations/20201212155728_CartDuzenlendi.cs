using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class CartDuzenlendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Carties",
                newName: "quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Carties",
                newName: "number");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Carts",
                type: "TEXT",
                nullable: true);
        }
    }
}
