using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class SalesLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesLineId",
                table: "SalesLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesLineId",
                table: "SalesLine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
