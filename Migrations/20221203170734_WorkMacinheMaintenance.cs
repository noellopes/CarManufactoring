using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class WorkMacinheMaintenance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

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
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    SectionManagerId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceTaskId = table.Column<int>(type: "int", nullable: false),
                    WorkStatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkMachineMaintenance", x => x.WorkMachineMaintenanceId);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkMachineMaintenance_WorkStates_WorkStatesId",
                        column: x => x.WorkStatesId,
                        principalTable: "WorkStates",
                        principalColumn: "WorkStatesId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_WorkMachineMaintenance_CollaboratorId",
                table: "WorkMachineMaintenance",
                column: "CollaboratorId");

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
                name: "WorkMachineMaintenance");

       
        }
    }
}
