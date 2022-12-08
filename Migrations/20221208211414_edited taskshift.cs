using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class editedtaskshift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
