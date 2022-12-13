using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineMaintenanceDateAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "SectionManager",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "MachineMaintenance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "MachineMaintenance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "MachineMaintenance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_PriorityId",
                table: "SectionManager",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_MachineId",
                table: "MachineMaintenance",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_PriorityId",
                table: "MachineMaintenance",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMaintenance_TaskTypeId",
                table: "MachineMaintenance",
                column: "TaskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineMaintenance_Machine_MachineId",
                table: "MachineMaintenance",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineMaintenance_Priority_PriorityId",
                table: "MachineMaintenance",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineMaintenance_TaskType_TaskTypeId",
                table: "MachineMaintenance",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionManager_Priority_PriorityId",
                table: "SectionManager",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "PriorityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineMaintenance_Machine_MachineId",
                table: "MachineMaintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineMaintenance_Priority_PriorityId",
                table: "MachineMaintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineMaintenance_TaskType_TaskTypeId",
                table: "MachineMaintenance");

            migrationBuilder.DropForeignKey(
                name: "FK_SectionManager_Priority_PriorityId",
                table: "SectionManager");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropIndex(
                name: "IX_SectionManager_PriorityId",
                table: "SectionManager");

            migrationBuilder.DropIndex(
                name: "IX_MachineMaintenance_MachineId",
                table: "MachineMaintenance");

            migrationBuilder.DropIndex(
                name: "IX_MachineMaintenance_PriorityId",
                table: "MachineMaintenance");

            migrationBuilder.DropIndex(
                name: "IX_MachineMaintenance_TaskTypeId",
                table: "MachineMaintenance");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "SectionManager");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MachineMaintenance");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "MachineMaintenance");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "MachineMaintenance");
        }
    }
}
