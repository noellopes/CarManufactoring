using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ListConfigMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigList",
                columns: table => new
                {
                    ConfigListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarConfigId = table.Column<int>(type: "int", nullable: false),
                    ExtraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigList", x => x.ConfigListId);
                    table.ForeignKey(
                        name: "FK_ConfigList_CarConfig_CarConfigId",
                        column: x => x.CarConfigId,
                        principalTable: "CarConfig",
                        principalColumn: "CarConfigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigList_Extra_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extra",
                        principalColumn: "ExtraID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigList_CarConfigId",
                table: "ConfigList",
                column: "CarConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigList_ExtraId",
                table: "ConfigList",
                column: "ExtraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigList");
        }
    }
}
