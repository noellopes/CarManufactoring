using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class InspectionAndTestReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinished_InspectionAndTest_InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.DropIndex(
                name: "IX_SemiFinished_InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.DropColumn(
                name: "InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_ReferenceId",
                table: "InspectionAndTest",
                column: "ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_ReferenceId",
                table: "InspectionAndTest",
                column: "ReferenceId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_ReferenceId",
                table: "InspectionAndTest");

            migrationBuilder.DropIndex(
                name: "IX_InspectionAndTest_ReferenceId",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "InspectionAndTest");

            migrationBuilder.AddColumn<int>(
                name: "InspectionAndTestInspectionId",
                table: "SemiFinished",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemiFinished_InspectionAndTestInspectionId",
                table: "SemiFinished",
                column: "InspectionAndTestInspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinished_InspectionAndTest_InspectionAndTestInspectionId",
                table: "SemiFinished",
                column: "InspectionAndTestInspectionId",
                principalTable: "InspectionAndTest",
                principalColumn: "InspectionId");
        }
    }
}
