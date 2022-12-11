using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Aquisition_FKMachineAquisitionID",
                table: "MachineBudget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Supplier_FKSupplierId",
                table: "MachineBudget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MachineBudget_Aquisition_FKMachineAquisitionID",
                table: "MachineBudget",
                column: "Aquisition_FKMachineAquisitionID");

            migrationBuilder.CreateIndex(
                name: "IX_MachineBudget_Supplier_FKSupplierId",
                table: "MachineBudget",
                column: "Supplier_FKSupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineBudget_MachineAquisition_Aquisition_FKMachineAquisitionID",
                table: "MachineBudget",
                column: "Aquisition_FKMachineAquisitionID",
                principalTable: "MachineAquisition",
                principalColumn: "MachineAquisitionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineBudget_Supplier_Supplier_FKSupplierId",
                table: "MachineBudget",
                column: "Supplier_FKSupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineBudget_MachineAquisition_Aquisition_FKMachineAquisitionID",
                table: "MachineBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineBudget_Supplier_Supplier_FKSupplierId",
                table: "MachineBudget");

            migrationBuilder.DropIndex(
                name: "IX_MachineBudget_Aquisition_FKMachineAquisitionID",
                table: "MachineBudget");

            migrationBuilder.DropIndex(
                name: "IX_MachineBudget_Supplier_FKSupplierId",
                table: "MachineBudget");

            migrationBuilder.DropColumn(
                name: "Aquisition_FKMachineAquisitionID",
                table: "MachineBudget");

            migrationBuilder.DropColumn(
                name: "Supplier_FKSupplierId",
                table: "MachineBudget");
        }
    }
}
