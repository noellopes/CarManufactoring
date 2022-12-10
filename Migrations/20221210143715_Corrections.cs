using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Corrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineAquisition",
                columns: table => new
                {
                    MachineAquisitionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineAquisitionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    QuantityOfParts = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProducedParts = table.Column<double>(type: "float", nullable: false),
                    MaintenancePrice = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAquisition", x => x.MachineAquisitionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineAquisition");
        }
    }
}
