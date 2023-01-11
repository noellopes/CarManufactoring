using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class warehouseproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarPartsProductId",
                table: "Warehouse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WarehouseProduct",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProduct", x => new { x.WarehouseId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WarehouseProduct_CarParts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "CarParts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseProduct_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseProduct_ProductId",
                table: "WarehouseProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_CarParts_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_CarParts_CarPartsProductId",
                table: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseProduct");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CarPartsProductId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CarPartsProductId",
                table: "Warehouse");
        }
    }
}
