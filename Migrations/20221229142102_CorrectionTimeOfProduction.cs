using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CorrectionTimeOfProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction",
                column: "CarConfigId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction");

            migrationBuilder.CreateIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction",
                column: "CarConfigId");
        }
    }
}
