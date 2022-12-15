using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class InspectionAndTestsSemiFinishedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_ReferenceId",
                table: "InspectionAndTest");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "InspectionAndTest",
                newName: "SemiFinishedId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionAndTest_ReferenceId",
                table: "InspectionAndTest",
                newName: "IX_InspectionAndTest_SemiFinishedId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_SemiFinishedId",
                table: "InspectionAndTest",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_SemiFinishedId",
                table: "InspectionAndTest");

            migrationBuilder.RenameColumn(
                name: "SemiFinishedId",
                table: "InspectionAndTest",
                newName: "ReferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionAndTest_SemiFinishedId",
                table: "InspectionAndTest",
                newName: "IX_InspectionAndTest_ReferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_ReferenceId",
                table: "InspectionAndTest",
                column: "ReferenceId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
