using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class semiFinishToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupplierContact",
                table: "Supplier",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reference",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SemiFinishedCar");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierContact",
                table: "Supplier",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
