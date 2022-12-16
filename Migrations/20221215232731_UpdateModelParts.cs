using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class UpdateModelParts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarModels_CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarParts_CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelParts",
                table: "ModelParts");

            migrationBuilder.DropIndex(
                name: "IX_ModelParts_CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropIndex(
                name: "IX_ModelParts_CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SemiFinishedCar");

            migrationBuilder.DropColumn(
                name: "ModelPartsId",
                table: "ModelParts");

            migrationBuilder.DropColumn(
                name: "CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropColumn(
                name: "CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.RenameColumn(
                name: "CarModelId",
                table: "ModelParts",
                newName: "CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelParts",
                table: "ModelParts",
                columns: new[] { "ProductId", "CarId" });

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarId",
                table: "ModelParts",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_Car_CarId",
                table: "ModelParts",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_CarParts_ProductId",
                table: "ModelParts",
                column: "ProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_Car_CarId",
                table: "ModelParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarParts_ProductId",
                table: "ModelParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelParts",
                table: "ModelParts");

            migrationBuilder.DropIndex(
                name: "IX_ModelParts_CarId",
                table: "ModelParts");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "ModelParts",
                newName: "CarModelId");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reference",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SemiFinishedCar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelPartsId",
                table: "ModelParts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CarModelsCarModelId",
                table: "ModelParts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarPartsProductId",
                table: "ModelParts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelParts",
                table: "ModelParts",
                column: "ModelPartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarModelsCarModelId",
                table: "ModelParts",
                column: "CarModelsCarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelParts_CarPartsProductId",
                table: "ModelParts",
                column: "CarPartsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_CarModels_CarModelsCarModelId",
                table: "ModelParts",
                column: "CarModelsCarModelId",
                principalTable: "CarModels",
                principalColumn: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelParts_CarParts_CarPartsProductId",
                table: "ModelParts",
                column: "CarPartsProductId",
                principalTable: "CarParts",
                principalColumn: "ProductId");
        }
    }
}
