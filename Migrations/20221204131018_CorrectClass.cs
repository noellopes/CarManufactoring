using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CorrectClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                   name: "MaintenanceTask",
                       columns: table => new
                       {
                           MaintenanceTaskId = table.Column<int>(type: "int", nullable: false)
                               .Annotation("SqlServer:Identity", "1, 1"),
                           TaskDef = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                       },
                       constraints: table =>
                       {
                           table.PrimaryKey("PK_MaintenanceTask", x => x.MaintenanceTaskId);
                       });

            

            migrationBuilder.CreateTable(
                name: "WorkMachineMaintenance",
                columns: table => new
                {
                    WorkMachineMaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceStateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkPriority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreviewStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachinesId = table.Column<int>(type: "int", nullable: false),
                    SectionManagerId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceTaskId = table.Column<int>(type: "int", nullable: false),
                    WorkStatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkMachineMaintenance", x => x.WorkMachineMaintenanceId);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_Machines_MachinesId",
                        column: x => x.MachinesId,
                        principalTable: "Machines",
                        principalColumn: "MachinesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_MaintenanceTask_MaintenanceTaskId",
                        column: x => x.MaintenanceTaskId,
                        principalTable: "MaintenanceTask",
                        principalColumn: "MaintenanceTaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_SectionManager_SectionManagerId",
                        column: x => x.SectionManagerId,
                        principalTable: "SectionManager",
                        principalColumn: "SectionManagerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_WorkStates_WorkStatesId",
                        column: x => x.WorkStatesId,
                        principalTable: "WorkStates",
                        principalColumn: "WorkStatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkMachineMaintenance_MachinesId",
                table: "WorkMachineMaintenance",
                column: "MachinesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMachineMaintenance_MaintenanceTaskId",
                table: "WorkMachineMaintenance",
                column: "MaintenanceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMachineMaintenance_SectionManagerId",
                table: "WorkMachineMaintenance",
                column: "SectionManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMachineMaintenance_WorkStatesId",
                table: "WorkMachineMaintenance",
                column: "WorkStatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                  name: "MaintenanceTask");

            migrationBuilder.DropTable(
                name: "WorkMachineMaintenance");

      
        }
    }
}
