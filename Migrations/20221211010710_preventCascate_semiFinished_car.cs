using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class preventCascate_semiFinished_car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinishedCar_Car_CarId",
                table: "SemiFinishedCar");

            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                table: "SemiFinishedCar");

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinishedCar_Car_CarId",
                table: "SemiFinishedCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                table: "SemiFinishedCar",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinishedCar_Car_CarId",
                table: "SemiFinishedCar");

            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                table: "SemiFinishedCar");

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinishedCar_Car_CarId",
                table: "SemiFinishedCar",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinishedCar_SemiFinished_SemiFinishedId",
                table: "SemiFinishedCar",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
