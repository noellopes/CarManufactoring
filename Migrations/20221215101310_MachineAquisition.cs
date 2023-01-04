using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class MachineAquisition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineBudget_MachineAquisition_AquisitionId",
                table: "MachineBudget");

            migrationBuilder.DropIndex(
                name: "IX_MachineBudget_AquisitionId",
                table: "MachineBudget");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierContact",
                table: "Supplier",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityOfParts",
                table: "MachineAquisition",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Operation",
                table: "MachineAquisition",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MachineBudgetId",
                table: "MachineAquisition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MachineAquisition_MachineBudgetId",
                table: "MachineAquisition",
                column: "MachineBudgetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAquisition_MachineBudget_MachineBudgetId",
                table: "MachineAquisition",
                column: "MachineBudgetId",
                principalTable: "MachineBudget",
                principalColumn: "MachineBudgetID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineAquisition_MachineBudget_MachineBudgetId",
                table: "MachineAquisition");

            migrationBuilder.DropIndex(
                name: "IX_MachineAquisition_MachineBudgetId",
                table: "MachineAquisition");

            migrationBuilder.DropColumn(
                name: "MachineBudgetId",
                table: "MachineAquisition");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierContact",
                table: "Supplier",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "QuantityOfParts",
                table: "MachineAquisition",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Operation",
                table: "MachineAquisition",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MachineBudget_AquisitionId",
                table: "MachineBudget",
                column: "AquisitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineBudget_MachineAquisition_AquisitionId",
                table: "MachineBudget",
                column: "AquisitionId",
                principalTable: "MachineAquisition",
                principalColumn: "MachineAquisitionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
