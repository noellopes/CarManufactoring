using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class Breakdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakdown",
                columns: table => new
                {
                    BreakdownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakdownName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BreakdownDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakdownNumber = table.Column<int>(type: "int", maxLength: 99, nullable: false),
                    ReparationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineStop = table.Column<int>(type: "int", maxLength: 99, nullable: false),
                    MachineReplacement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdown", x => x.BreakdownId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakdown");
        }
    }
}
