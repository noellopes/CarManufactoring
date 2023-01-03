using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class WarehouseStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Collaborator_CollaboratorId",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "CollaboratorId",
                table: "Stock",
                newName: "WarehouseStockId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock",
                newName: "IX_Stock_WarehouseStockId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stock",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "WarehouseStock",
                columns: table => new
                {
                    WarehouseStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseStock", x => x.WarehouseStockId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_WarehouseStock_WarehouseStockId",
                table: "Stock",
                column: "WarehouseStockId",
                principalTable: "WarehouseStock",
                principalColumn: "WarehouseStockId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_WarehouseStock_WarehouseStockId",
                table: "Stock");

            migrationBuilder.DropTable(
                name: "WarehouseStock");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stock");

            migrationBuilder.RenameColumn(
                name: "WarehouseStockId",
                table: "Stock",
                newName: "CollaboratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_WarehouseStockId",
                table: "Stock",
                newName: "IX_Stock_CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Collaborator_CollaboratorId",
                table: "Stock",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
