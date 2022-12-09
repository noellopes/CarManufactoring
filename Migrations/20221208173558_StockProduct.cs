using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class StockProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollaboratorId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock",
                column: "CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Collaborator_CollaboratorId",
                table: "Stock",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Collaborator_CollaboratorId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "Stock");
        }
    }
}
