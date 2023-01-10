using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class PriceSupp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceSupplierPartsCarParts",
                columns: table => new
                {
                    PriceSupplierPartsCarPartsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierPartsId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    Promocao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSupplierPartsCarParts", x => x.PriceSupplierPartsCarPartsId);
                    table.ForeignKey(
                        name: "FK_PriceSupplierPartsCarParts_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceSupplierPartsCarParts_SupplierParts_SupplierPartsId",
                        column: x => x.SupplierPartsId,
                        principalTable: "SupplierParts",
                        principalColumn: "SupplierPartsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceSupplierPartsCarParts_ProductId",
                table: "PriceSupplierPartsCarParts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceSupplierPartsCarParts_SupplierPartsId",
                table: "PriceSupplierPartsCarParts",
                column: "SupplierPartsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceSupplierPartsCarParts");
        }
    }
}
