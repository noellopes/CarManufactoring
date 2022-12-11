using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class semiFinished_Car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId",
                table: "Car");

            migrationBuilder.DropTable(
                name: "MaterialUsado");

            migrationBuilder.DropIndex(
                name: "IX_Car_SemiFinishedId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SemiFinishedId",
                table: "Car");

            migrationBuilder.CreateTable(
                name: "SemiFinishedCar",
                columns: table => new
                {
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemiFinishedCar", x => new { x.SemiFinishedId, x.CarId });
                    table.ForeignKey(
                        name: "FK_SemiFinishedCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemiFinishedCar_CarId",
                table: "SemiFinishedCar",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemiFinishedCar");

            migrationBuilder.AddColumn<int>(
                name: "SemiFinishedId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialUsado",
                columns: table => new
                {
                    MaterialUsadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemiFinishedId = table.Column<int>(type: "int", nullable: false),
                    SemiFinishedNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialUsado", x => x.MaterialUsadoId);
                    table.ForeignKey(
                        name: "FK_MaterialUsado_SemiFinished_SemiFinishedId",
                        column: x => x.SemiFinishedId,
                        principalTable: "SemiFinished",
                        principalColumn: "SemiFinishedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_SemiFinishedId",
                table: "Car",
                column: "SemiFinishedId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_SemiFinishedId",
                table: "MaterialUsado",
                column: "SemiFinishedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_SemiFinished_SemiFinishedId",
                table: "Car",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId");
        }
    }
}
