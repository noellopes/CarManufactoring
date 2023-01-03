using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class UpdateInspectionAndTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "InspectionAndTest");

            migrationBuilder.AddColumn<int>(
                name: "ProductionsId",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityTested",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_ProductionsId",
                table: "InspectionAndTest",
                column: "ProductionsId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_StateId",
                table: "InspectionAndTest",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_InspectionTestState_StateId",
                table: "InspectionAndTest",
                column: "StateId",
                principalTable: "InspectionTestState",
                principalColumn: "InspectionTestStateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_Production_ProductionsId",
                table: "InspectionAndTest",
                column: "ProductionsId",
                principalTable: "Production",
                principalColumn: "ProductionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_InspectionTestState_StateId",
                table: "InspectionAndTest");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_Production_ProductionsId",
                table: "InspectionAndTest");

            migrationBuilder.DropIndex(
                name: "IX_InspectionAndTest_ProductionsId",
                table: "InspectionAndTest");

            migrationBuilder.DropIndex(
                name: "IX_InspectionAndTest_StateId",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "ProductionsId",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "QuantityTested",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "InspectionAndTest");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "InspectionAndTest",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
