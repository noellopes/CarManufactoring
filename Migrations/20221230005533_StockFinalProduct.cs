using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class StockFinalProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockFinalProduct",
                columns: table => new
                {
                    StockFinalProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalizationCarId = table.Column<int>(type: "int", nullable: false),
                    ChassiNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockFinalProduct", x => x.StockFinalProductId);
                    table.ForeignKey(
                        name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId",
                        column: x => x.LocalizationCarId,
                        principalTable: "LocalizationCar",
                        principalColumn: "LocalizationCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockFinalProduct_Production_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Production",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_LocalizationCarId",
                table: "StockFinalProduct",
                column: "LocalizationCarId");

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_ProductionId",
                table: "StockFinalProduct",
                column: "ProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockFinalProduct");
        }
    }
}
