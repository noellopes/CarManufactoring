using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class StockFinalProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId1",
                table: "StockFinalProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockFinalProduct",
                table: "StockFinalProduct");

            migrationBuilder.DropIndex(
                name: "IX_StockFinalProduct_LocalizationCarId1",
                table: "StockFinalProduct");

            migrationBuilder.RenameColumn(
                name: "LocalizationCarId1",
                table: "StockFinalProduct",
                newName: "StockFinalProductId");

            migrationBuilder.AlterColumn<int>(
                name: "LocalizationCarId",
                table: "StockFinalProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StockFinalProductId",
                table: "StockFinalProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockFinalProduct",
                table: "StockFinalProduct",
                column: "StockFinalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_LocalizationCarId",
                table: "StockFinalProduct",
                column: "LocalizationCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId",
                table: "StockFinalProduct",
                column: "LocalizationCarId",
                principalTable: "LocalizationCar",
                principalColumn: "LocalizationCarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId",
                table: "StockFinalProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockFinalProduct",
                table: "StockFinalProduct");

            migrationBuilder.DropIndex(
                name: "IX_StockFinalProduct_LocalizationCarId",
                table: "StockFinalProduct");

            migrationBuilder.RenameColumn(
                name: "StockFinalProductId",
                table: "StockFinalProduct",
                newName: "LocalizationCarId1");

            migrationBuilder.AlterColumn<int>(
                name: "LocalizationCarId",
                table: "StockFinalProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "LocalizationCarId1",
                table: "StockFinalProduct",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockFinalProduct",
                table: "StockFinalProduct",
                column: "LocalizationCarId");

            migrationBuilder.CreateIndex(
                name: "IX_StockFinalProduct_LocalizationCarId1",
                table: "StockFinalProduct",
                column: "LocalizationCarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockFinalProduct_LocalizationCar_LocalizationCarId1",
                table: "StockFinalProduct",
                column: "LocalizationCarId1",
                principalTable: "LocalizationCar",
                principalColumn: "LocalizationCarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
