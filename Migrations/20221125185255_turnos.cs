using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class turnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnoColaboradores",
                columns: table => new
                {
                    TurnoColaboradoresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horas_turno = table.Column<int>(type: "int", nullable: false),
                    dataInicio = table.Column<int>(type: "int", nullable: false),
                    dataFim = table.Column<int>(type: "int", nullable: false),
                    turnoEstado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dataEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoColaboradores", x => x.TurnoColaboradoresId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnoColaboradores");
        }
    }
}
