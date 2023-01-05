using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class RecreateTableMaterialUsedsDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialUsed",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    MaterialUsedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsed", x => new { x.MaterialId, x.SemiFinishedId });
                    table.ForeignKey(
                        name: "FK_MaterialUsed_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsed_SemiFinishedId",
                table: "MaterialUsed",
                column: "SemiFinishedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialUsed");
        }
    }
}
