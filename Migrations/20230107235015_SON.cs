using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class SON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPunctuality_Collaborator_WorkerCollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.DropIndex(
                name: "IX_WorkerPunctuality_WorkerCollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.DropColumn(
                name: "WorkerCollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.AddColumn<int>(
                name: "CollaboratorId",
                table: "WorkerPunctuality",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPunctuality_CollaboratorId",
                table: "WorkerPunctuality",
                column: "CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPunctuality_Collaborator_CollaboratorId",
                table: "WorkerPunctuality",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPunctuality_Collaborator_CollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.DropIndex(
                name: "IX_WorkerPunctuality_CollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "WorkerPunctuality");

            migrationBuilder.AddColumn<int>(
                name: "WorkerCollaboratorId",
                table: "WorkerPunctuality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPunctuality_WorkerCollaboratorId",
                table: "WorkerPunctuality",
                column: "WorkerCollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPunctuality_Collaborator_WorkerCollaboratorId",
                table: "WorkerPunctuality",
                column: "WorkerCollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
