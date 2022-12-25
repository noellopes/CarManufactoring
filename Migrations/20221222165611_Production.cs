using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Production : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Production");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Production",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "MaxQuantity",
                table: "Production",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Production",
                newName: "MaxQuantity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Production",
                newName: "OrderDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Production",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
