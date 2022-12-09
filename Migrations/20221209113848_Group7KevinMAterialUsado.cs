using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Group7KevinMAterialUsado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierAddress",
                table: "Supplier",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupplierZipCode",
                table: "Supplier",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Stock",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CollaboratorId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SemiFinishedId1",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_MaterialId",
                table: "Car",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_SemiFinishedId1",
                table: "Car",
                column: "SemiFinishedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Material_MaterialId",
                table: "Car",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId1",
                table: "Car",
                column: "SemiFinishedId1",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId");

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
                name: "FK_Car_Material_MaterialId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId1",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Collaborator_CollaboratorId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_CollaboratorId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Car_MaterialId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_SemiFinishedId1",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SupplierAddress",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierZipCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SemiFinishedId1",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "Quantity",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
