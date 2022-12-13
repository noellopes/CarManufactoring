using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineMaintenanceDateAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "MachineMaintenance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_TaskTypeId",
                table: "MachineMaintenance",
                column: "TaskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineMaintenance_TaskType_TaskTypeId",
                table: "MachineMaintenance",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineMaintenance_TaskType_TaskTypeId",
                table: "MachineMaintenance");

            migrationBuilder.DropIndex(
                name: "IX_MachineMaintenance_TaskTypeId",
                table: "MachineMaintenance");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "MachineMaintenance");
        }
    }
}
