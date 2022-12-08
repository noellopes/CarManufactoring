using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CarParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarBrand",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "CarType",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "StockState",
                table: "CarParts");

            migrationBuilder.AlterColumn<double>(
                name: "SafetyStock",
                table: "CarParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "CarParts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<double>(
                name: "PointOfPurchase",
                table: "CarParts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PartType",
                table: "CarParts",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartType",
                table: "CarParts");

            migrationBuilder.AlterColumn<int>(
                name: "SafetyStock",
                table: "CarParts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "CarParts",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "PointOfPurchase",
                table: "CarParts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "CarBrand",
                table: "CarParts",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "CarParts",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarType",
                table: "CarParts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockState",
                table: "CarParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
