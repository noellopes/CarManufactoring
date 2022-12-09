using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class TaskCollaborationClassesreconstructedv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assigment");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Collaborator",
                newName: "OnDuty");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Collaborator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Collaborator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Collaborator",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_TaskId",
                table: "Collaborator",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_Task_TaskId",
                table: "Collaborator",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Task_TaskId",
                table: "Collaborator");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Collaborator_TaskId",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "TaskId",
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
        }
    }
}
