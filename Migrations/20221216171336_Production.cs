using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Production : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarConfigId",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxQuantity",
                table: "Production",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Production_CarConfigId",
                table: "Production",
                column: "CarConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Production_CarConfig_CarConfigId",
                table: "Production",
                column: "CarConfigId",
                principalTable: "CarConfig",
                principalColumn: "CarConfigId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Production_CarConfig_CarConfigId",
                table: "Production");

            migrationBuilder.DropIndex(
                name: "IX_Production_CarConfigId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "CarConfigId",
                table: "Production");

            migrationBuilder.DropColumn(
                name: "MaxQuantity",
                table: "Production");
        }
    }
}
