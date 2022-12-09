using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class CollaboratorGenderRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Collaborator");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Collaborator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_GenderId",
                table: "Collaborator",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborator_Gender_GenderId",
                table: "Collaborator",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborator_Gender_GenderId",
                table: "Collaborator");

            migrationBuilder.DropIndex(
                name: "IX_Collaborator_GenderId",
                table: "Collaborator");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Collaborator");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Collaborator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
