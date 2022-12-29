using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class InspectionTestsProductions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_SemiFinishedId",
                table: "InspectionAndTest");

            migrationBuilder.DropIndex(
                name: "IX_InspectionAndTest_SemiFinishedId",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "SemiFinishedId",
                table: "InspectionAndTest");

            migrationBuilder.CreateTable(
                name: "InspectionTestsProduction",
                columns: table => new
                {
                    InspectionTestsProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lote = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    InspectionAndTestInspectionId = table.Column<int>(type: "int", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionTestsProduction", x => x.InspectionTestsProductionId);
                    table.ForeignKey(
                        name: "FK_InspectionTestsProduction_InspectionAndTest_InspectionAndTestInspectionId",
                        column: x => x.InspectionAndTestInspectionId,
                        principalTable: "InspectionAndTest",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionTestsProduction_Production_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Production",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTestsProduction_InspectionAndTestInspectionId",
                table: "InspectionTestsProduction",
                column: "InspectionAndTestInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionTestsProduction_ProductionId",
                table: "InspectionTestsProduction",
                column: "ProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionTestsProduction");

            migrationBuilder.AddColumn<int>(
                name: "SemiFinishedId",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_SemiFinishedId",
                table: "InspectionAndTest",
                column: "SemiFinishedId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_SemiFinished_SemiFinishedId",
                table: "InspectionAndTest",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
