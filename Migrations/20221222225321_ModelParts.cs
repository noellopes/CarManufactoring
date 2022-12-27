using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ModelParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_StockProduct_StockProductId",
                table: "ModelParts");

            migrationBuilder.DropTable(
                name: "StockProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "CarParts");

            migrationBuilder.RenameColumn(
                name: "StockProductId",
                table: "ModelParts",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "PartType",
                table: "CarParts",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarParts",
                table: "CarParts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_CarParts_ProductId",
                table: "ModelParts",
                column: "ProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarParts_ProductId",
                table: "ModelParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarParts",
                table: "CarParts");

            migrationBuilder.RenameTable(
                name: "CarParts",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ModelParts",
                newName: "StockProductId");

            migrationBuilder.AlterColumn<string>(
                name: "PartType",
                table: "Product",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "StockProduct",
                columns: table => new
                {
                    StockProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    StockMax = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockProduct", x => x.StockProductId);
                    table.ForeignKey(
                        name: "FK_StockProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockProduct_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockProduct_ProductId",
                table: "StockProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProduct_StockId",
                table: "StockProduct",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_StockProduct_StockProductId",
                table: "ModelParts",
                column: "StockProductId",
                principalTable: "StockProduct",
                principalColumn: "StockProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
