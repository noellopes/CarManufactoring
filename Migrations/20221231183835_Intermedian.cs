using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Intermedian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierPartsCarParts",
                columns: table => new
                {
                    SupplierPartsId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PrazoEntrega = table.Column<int>(type: "int", nullable: false),
                    Disponibilidade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPartsCarParts", x => new { x.SupplierPartsId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupplierPartsCarParts_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierPartsCarParts_SupplierParts_SupplierPartsId",
                        column: x => x.SupplierPartsId,
                        principalTable: "SupplierParts",
                        principalColumn: "SupplierPartsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPartsCarParts_ProductId",
                table: "SupplierPartsCarParts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierPartsCarParts");
        }
    }
}
