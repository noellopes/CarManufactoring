using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class warehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Collaborator_CollaboratorID",
                table: "Warehouse");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Collaborator_CollaboratorID",
                table: "Warehouse",
                column: "CollaboratorID",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Collaborator_CollaboratorID",
                table: "Warehouse");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Collaborator_CollaboratorID",
                table: "Warehouse",
                column: "CollaboratorID",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
