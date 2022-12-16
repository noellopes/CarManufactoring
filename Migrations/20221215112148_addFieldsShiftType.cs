using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class addFieldsShiftType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftTypeSearchShiftTypeId",
                table: "ShiftType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftType_ShiftTypeSearchShiftTypeId",
                table: "ShiftType",
                column: "ShiftTypeSearchShiftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftType_ShiftType_ShiftTypeSearchShiftTypeId",
                table: "ShiftType",
                column: "ShiftTypeSearchShiftTypeId",
                principalTable: "ShiftType",
                principalColumn: "ShiftTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShiftType_ShiftType_ShiftTypeSearchShiftTypeId",
                table: "ShiftType");

            migrationBuilder.DropIndex(
                name: "IX_ShiftType_ShiftTypeSearchShiftTypeId",
                table: "ShiftType");

            migrationBuilder.DropColumn(
                name: "ShiftTypeSearchShiftTypeId",
                table: "ShiftType");
        }
    }
}
