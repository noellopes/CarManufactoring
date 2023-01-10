using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class implementsNewAttributtes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "custoManutencao",
                table: "MachineBudget",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "prazoGarantia",
                table: "MachineBudget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custoManutencao",
                table: "MachineBudget");

            migrationBuilder.DropColumn(
                name: "prazoGarantia",
                table: "MachineBudget");
        }
    }
}
