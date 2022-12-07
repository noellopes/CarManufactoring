using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemiFinishedId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_SemiFinishedId",
                table: "Car",
                column: "SemiFinishedId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_MaterialId",
                table: "Stock",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId",
                table: "Car",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Car_SemiFinishedId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SemiFinishedId",
                table: "Car");
        }
    }
}
