using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerlitzTest.Migrations
{
    public partial class ChangingProductNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PoductNumber",
                table: "Products",
                newName: "ProductNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductNumber",
                table: "Products",
                newName: "PoductNumber");
        }
    }
}
