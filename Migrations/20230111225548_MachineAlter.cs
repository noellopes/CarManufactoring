using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Section_SectionId",
                table: "Machine");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Machine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Machine",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocalizationCodeId",
                table: "Machine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Machine_LocalizationCodeId",
                table: "Machine",
                column: "LocalizationCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_LocalizationCode_LocalizationCodeId",
                table: "Machine",
                column: "LocalizationCodeId",
                principalTable: "LocalizationCode",
                principalColumn: "LocalizationCodeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Section_SectionId",
                table: "Machine",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machine_LocalizationCode_LocalizationCodeId",
                table: "Machine");

            migrationBuilder.DropForeignKey(
                name: "FK_Machine_Section_SectionId",
                table: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Machine_LocalizationCodeId",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Machine");

            migrationBuilder.DropColumn(
                name: "LocalizationCodeId",
                table: "Machine");

            migrationBuilder.AlterColumn<int>(
                name: "SectionId",
                table: "Machine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machine_Section_SectionId",
                table: "Machine",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
