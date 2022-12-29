using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionAndTestInspectionId",
                table: "InspectionTestsProduction");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTestsProduction_Production_ProductionId",
                table: "InspectionTestsProduction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionTestsProduction",
                table: "InspectionTestsProduction");

            migrationBuilder.DropIndex(
                name: "IX_InspectionTestsProduction_InspectionAndTestInspectionId",
                table: "InspectionTestsProduction");

            migrationBuilder.DropColumn(
                name: "InspectionAndTestInspectionId",
                table: "InspectionTestsProduction");

            migrationBuilder.AlterColumn<int>(
                name: "InspectionTestsProductionId",
                table: "InspectionTestsProduction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionTestsProduction",
                table: "InspectionTestsProduction",
                columns: new[] { "InspectionId", "ProductionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionId",
                table: "InspectionTestsProduction",
                column: "InspectionId",
                principalTable: "InspectionAndTest",
                principalColumn: "InspectionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTestsProduction_Production_ProductionId",
                table: "InspectionTestsProduction",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "ProductionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionId",
                table: "InspectionTestsProduction");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionTestsProduction_Production_ProductionId",
                table: "InspectionTestsProduction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionTestsProduction",
                table: "InspectionTestsProduction");

            migrationBuilder.AlterColumn<int>(
                name: "InspectionTestsProductionId",
                table: "InspectionTestsProduction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InspectionAndTestInspectionId",
                table: "InspectionTestsProduction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionTestsProduction",
                table: "InspectionTestsProduction",
                column: "InspectionTestsProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTestsProduction_InspectionAndTestInspectionId",
                table: "InspectionTestsProduction",
                column: "InspectionAndTestInspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionAndTestInspectionId",
                table: "InspectionTestsProduction",
                column: "InspectionAndTestInspectionId",
                principalTable: "InspectionAndTest",
                principalColumn: "InspectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionTestsProduction_Production_ProductionId",
                table: "InspectionTestsProduction",
                column: "ProductionId",
                principalTable: "Production",
                principalColumn: "ProductionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
