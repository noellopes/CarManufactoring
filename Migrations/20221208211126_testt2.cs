using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class testt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorShift_Collaborator_CollaboratorId",
                table: "CollaboratorShift");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorShift_Shift_ShiftId",
                table: "CollaboratorShift");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Collaborator_CollaboratorId",
                table: "CollaboratorTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId",
                table: "CollaboratorTask");

            migrationBuilder.AddColumn<int>(
                name: "TaskId1",
                table: "CollaboratorTask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTask_TaskId1",
                table: "CollaboratorTask",
                column: "TaskId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorShift_Collaborator_CollaboratorId",
                table: "CollaboratorShift",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorShift_Shift_ShiftId",
                table: "CollaboratorShift",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Collaborator_CollaboratorId",
                table: "CollaboratorTask",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId",
                table: "CollaboratorTask",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId1",
                table: "CollaboratorTask",
                column: "TaskId1",
                principalTable: "Task",
                principalColumn: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorShift_Collaborator_CollaboratorId",
                table: "CollaboratorShift");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorShift_Shift_ShiftId",
                table: "CollaboratorShift");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Collaborator_CollaboratorId",
                table: "CollaboratorTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId",
                table: "CollaboratorTask");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId1",
                table: "CollaboratorTask");

            migrationBuilder.DropIndex(
                name: "IX_CollaboratorTask_TaskId1",
                table: "CollaboratorTask");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "CollaboratorTask");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorShift_Collaborator_CollaboratorId",
                table: "CollaboratorShift",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorShift_Shift_ShiftId",
                table: "CollaboratorShift",
                column: "ShiftId",
                principalTable: "Shift",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Collaborator_CollaboratorId",
                table: "CollaboratorTask",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTask_Task_TaskId",
                table: "CollaboratorTask",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
