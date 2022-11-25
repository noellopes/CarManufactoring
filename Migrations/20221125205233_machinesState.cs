using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class machinesState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineState",
                columns: table => new
                {
                    MachineStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateMachine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineState", x => x.MachineStateId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachinesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineBrand = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MachineModel = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    AquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineStateId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineStateId",
                table: "Machines",
                column: "MachineStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "MachineState");
        }
    }
}
