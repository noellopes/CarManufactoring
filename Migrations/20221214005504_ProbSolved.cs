using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class ProbSolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PecaId",
                table: "ModelParts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ModeloId",
                table: "ModelParts",
                newName: "CarModelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ModelParts",
                newName: "ModelPartsId");

            migrationBuilder.RenameColumn(
                name: "CarModel_Id",
                table: "CarModels",
                newName: "CarModelId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarModels_CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelParts_CarParts_CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.DropIndex(
                name: "IX_ModelParts_CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropIndex(
                name: "IX_ModelParts_CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.DropColumn(
                name: "CarModelsCarModelId",
                table: "ModelParts");

            migrationBuilder.DropColumn(
                name: "CarPartsProductId",
                table: "ModelParts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ModelParts",
                newName: "PecaId");

            migrationBuilder.RenameColumn(
                name: "CarModelId",
                table: "ModelParts",
                newName: "ModeloId");

            migrationBuilder.RenameColumn(
                name: "ModelPartsId",
                table: "ModelParts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarModelId",
                table: "CarModels",
                newName: "CarModel_Id");
        }
    }
}
