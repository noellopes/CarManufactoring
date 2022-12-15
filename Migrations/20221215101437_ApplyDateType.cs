using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ApplyDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Expected_End_Date",
                table: "MachineMaintenance",
                newName: "ExpectedEndDate");

            migrationBuilder.RenameColumn(
                name: "Effective_End_Date",
                table: "MachineMaintenance",
                newName: "EffectiveEndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedEndDate",
                table: "MachineMaintenance",
                newName: "Expected_End_Date");

            migrationBuilder.RenameColumn(
                name: "EffectiveEndDate",
                table: "MachineMaintenance",
                newName: "Effective_End_Date");
        }
    }
}
