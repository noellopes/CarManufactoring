using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class warehouseproduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_CarParts_CarPartsProductId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_CarPartsProductId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CarPartsProductId",
                table: "Warehouse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarPartsProductId",
                table: "Warehouse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_CarParts_CarPartsProductId",
                table: "Warehouse",
                column: "CarPartsProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId");
        }
    }
}
