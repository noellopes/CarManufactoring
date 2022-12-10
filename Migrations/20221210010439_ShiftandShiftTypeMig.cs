using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ShiftandShiftTypeMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftTypeId",
                table: "Shift",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShiftType",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTime = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftType", x => x.ShiftTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftTypeId",
                table: "Shift",
                column: "ShiftTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_ShiftType_ShiftTypeId",
                table: "Shift",
                column: "ShiftTypeId",
                principalTable: "ShiftType",
                principalColumn: "ShiftTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_ShiftType_ShiftTypeId",
                table: "Shift");

            migrationBuilder.DropTable(
                name: "ShiftType");

            migrationBuilder.DropIndex(
                name: "IX_Shift_ShiftTypeId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "ShiftTypeId",
                table: "Shift");
        }
    }
}
