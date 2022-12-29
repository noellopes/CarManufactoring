using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CorrectionFKTimeOfProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction",
                column: "CarConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOfProduction_CarConfig_CarConfigId",
                table: "TimeOfProduction",
                column: "CarConfigId",
                principalTable: "CarConfig",
                principalColumn: "CarConfigId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeOfProduction_CarConfig_CarConfigId",
                table: "TimeOfProduction");

            migrationBuilder.DropIndex(
                name: "IX_TimeOfProduction_CarConfigId",
                table: "TimeOfProduction");
        }
    }
}
