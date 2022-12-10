using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CorrectMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inspectionAndTestings",
                table: "inspectionAndTestings");

            migrationBuilder.RenameTable(
                name: "inspectionAndTestings",
                newName: "InspectionAndTest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionAndTest",
                table: "InspectionAndTest",
                column: "InspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionAndTest",
                table: "InspectionAndTest");

            migrationBuilder.RenameTable(
                name: "InspectionAndTest",
                newName: "inspectionAndTestings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inspectionAndTestings",
                table: "inspectionAndTestings",
                column: "InspectionId");
        }
    }
}
