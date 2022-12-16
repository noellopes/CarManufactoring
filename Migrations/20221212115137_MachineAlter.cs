using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "WorkStates");

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineModelId = table.Column<int>(type: "int", nullable: false),
                    MachineStateId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_Machine_MachineModel_MachineModelId",
                        column: x => x.MachineModelId,
                        principalTable: "MachineModel",
                        principalColumn: "MachineModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_MachineState_MachineStateId",
                        column: x => x.MachineStateId,
                        principalTable: "MachineState",
                        principalColumn: "MachineStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineModelId",
                table: "Machine",
                column: "MachineModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_MachineStateId",
                table: "Machine",
                column: "MachineStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_SectionId",
                table: "Machine",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachinesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineStateId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    AquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineBrand = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MachineModel = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachinesId);
                    table.ForeignKey(
                        name: "FK_Machines_MachineState_MachineStateId",
                        column: x => x.MachineStateId,
                        principalTable: "MachineState",
                        principalColumn: "MachineStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machines_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkStates",
                columns: table => new
                {
                    WorkStatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateWork = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStates", x => x.WorkStatesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineStateId",
                table: "Machines",
                column: "MachineStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_SectionId",
                table: "Machines",
                column: "SectionId");
        }
    }
}
