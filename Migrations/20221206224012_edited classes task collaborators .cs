using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class editedclassestaskcollaborators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assigment");

            migrationBuilder.DropTable(
                name: "TurnoColaboradores");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Collaborator",
                newName: "OnDuty");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Collaborator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftHours = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorTask",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorTask", x => new { x.TaskId, x.CollaboratorId });
                    table.ForeignKey(
                        name: "FK_CollaboratorTask_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorTask_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_ShiftId",
                table: "Collaborator",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTask_CollaboratorId",
                table: "CollaboratorTask",
                column: "CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_Shift_ShiftId",
                table: "Collaborator",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Shift_ShiftId",
                table: "Collaborator");

            migrationBuilder.DropTable(
                name: "CollaboratorTask");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Collaborator_ShiftId",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Collaborator");

            migrationBuilder.RenameColumn(
                name: "OnDuty",
                table: "Collaborator",
                newName: "Available");

            migrationBuilder.CreateTable(
                name: "Assigment",
                columns: table => new
                {
                    AssigmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LimitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigment", x => x.AssigmentId);
                });

            migrationBuilder.CreateTable(
                name: "TurnoColaboradores",
                columns: table => new
                {
                    TurnoColaboradoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horas_turno = table.Column<int>(type: "int", nullable: false),
                    turnoEstado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoColaboradores", x => x.TurnoColaboradoresId);
                });
        }
    }
}
