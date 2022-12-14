using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class InspectionAndTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Material_MaterialId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_MaterialId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "InspectionAndTestInspectionId",
                table: "SemiFinished",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollaboratorId",
                table: "InspectionAndTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SemiFinished_InspectionAndTestInspectionId",
                table: "SemiFinished",
                column: "InspectionAndTestInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsado_MaterialId",
                table: "MaterialUsado",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionAndTest_CollaboratorId",
                table: "InspectionAndTest",
                column: "CollaboratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionAndTest_Collaborator_CollaboratorId",
                table: "InspectionAndTest",
                column: "CollaboratorId",
                principalTable: "Collaborator",
                principalColumn: "CollaboratorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUsado_Material_MaterialId",
                table: "MaterialUsado",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemiFinished_InspectionAndTest_InspectionAndTestInspectionId",
                table: "SemiFinished",
                column: "InspectionAndTestInspectionId",
                principalTable: "InspectionAndTest",
                principalColumn: "InspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionAndTest_Collaborator_CollaboratorId",
                table: "InspectionAndTest");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUsado_Material_MaterialId",
                table: "MaterialUsado");

            migrationBuilder.DropForeignKey(
                name: "FK_SemiFinished_InspectionAndTest_InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.DropIndex(
                name: "IX_SemiFinished_InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.DropIndex(
                name: "IX_MaterialUsado_MaterialId",
                table: "MaterialUsado");

            migrationBuilder.DropIndex(
                name: "IX_InspectionAndTest_CollaboratorId",
                table: "InspectionAndTest");

            migrationBuilder.DropColumn(
                name: "InspectionAndTestInspectionId",
                table: "SemiFinished");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                table: "InspectionAndTest");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_MaterialId",
                table: "Car",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Material_MaterialId",
                table: "Car",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId");
        }
    }
}
