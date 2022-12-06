using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ShiftCollaborator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnoColaboradores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnoColaboradores",
                columns: table => new
                {
                    TurnoColaboradoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horas_turno = table.Column<int>(type: "int", nullable: false),
                    turnoEstado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoColaboradores", x => x.TurnoColaboradoresId);
                });
        }
    }
}
