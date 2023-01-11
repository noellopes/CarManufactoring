using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class hb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "MachineAquisition");

            migrationBuilder.RenameColumn(
                name: "ProducedParts",
                table: "MachineAquisition",
                newName: "NextLevel");

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "MachineAquisition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MachineAquisition_MachineId",
                table: "MachineAquisition",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAquisition_Machine_MachineId",
                table: "MachineAquisition",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineAquisition_Machine_MachineId",
                table: "MachineAquisition");

            migrationBuilder.DropIndex(
                name: "IX_MachineAquisition_MachineId",
                table: "MachineAquisition");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MachineAquisition");

            migrationBuilder.RenameColumn(
                name: "NextLevel",
                table: "MachineAquisition",
                newName: "ProducedParts");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "MachineAquisition",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
