using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerlitzTest.Migrations
{
    public partial class AddingProductNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoductNumber",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PoductNumber",
                table: "Products");
        }
    }
}
