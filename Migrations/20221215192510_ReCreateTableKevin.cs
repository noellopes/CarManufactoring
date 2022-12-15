using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ReCreateTableKevin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialUsado");

            migrationBuilder.CreateTable(
                name: "MaterialUsed",
                columns: table => new
                {
                    MaterialUsedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsed", x => x.MaterialUsedId);
                    table.ForeignKey(
                        name: "FK_MaterialUsed_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsed_MaterialId",
                table: "MaterialUsed",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsed_SemiFinishedId",
                table: "MaterialUsed",
                column: "SemiFinishedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialUsed");

            migrationBuilder.CreateTable(
                name: "MaterialUsado",
                columns: table => new
                {
                    MaterialUsadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsado", x => x.MaterialUsadoId);
                    table.ForeignKey(
                        name: "FK_MaterialUsado_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialUsado_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_MaterialId",
                table: "MaterialUsado",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_SemiFinishedId",
                table: "MaterialUsado",
                column: "SemiFinishedId");
        }
    }
}
