using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class reconstructingclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Shift_ShiftId",
                table: "Collaborator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorTask",
                table: "CollaboratorTask");

            migrationBuilder.DropIndex(
                name: "IX_Collaborator_ShiftId",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Collaborator");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "CollaboratorTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Collaborator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorTask",
                table: "CollaboratorTask",
                columns: new[] { "ShiftId", "TaskId", "CollaboratorId" });

            migrationBuilder.CreateTable(
                name: "CollaboratorShift",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorShift", x => new { x.ShiftId, x.CollaboratorId });
                    table.ForeignKey(
                        name: "FK_CollaboratorShift_Collaborator_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorShift_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTask_ShiftId_CollaboratorId",
                table: "CollaboratorTask",
                columns: new[] { "ShiftId", "CollaboratorId" });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTask_TaskId",
                table: "CollaboratorTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorShift_CollaboratorId",
                table: "CollaboratorShift",
                column: "CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_CollaboratorShift_ShiftId_CollaboratorId",
                table: "CollaboratorTask",
                columns: new[] { "ShiftId", "CollaboratorId" },
                principalTable: "CollaboratorShift",
                principalColumns: new[] { "ShiftId", "CollaboratorId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_CollaboratorShift_ShiftId_CollaboratorId",
                table: "CollaboratorTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Shift_ShiftId",
                table: "CollaboratorTask");

            migrationBuilder.DropTable(
                name: "CollaboratorShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorTask",
                table: "CollaboratorTask");

            migrationBuilder.DropIndex(
                name: "IX_CollaboratorTask_ShiftId_CollaboratorId",
                table: "CollaboratorTask");

            migrationBuilder.DropIndex(
                name: "IX_CollaboratorTask_TaskId",
                table: "CollaboratorTask");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "CollaboratorTask");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Collaborator");

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Collaborator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorTask",
                table: "CollaboratorTask",
                columns: new[] { "TaskId", "CollaboratorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_ShiftId",
                table: "Collaborator",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_Shift_ShiftId",
                table: "Collaborator",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
