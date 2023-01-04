using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class G7KevinDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUsed_Material_MaterialId",
                table: "MaterialUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                table: "MaterialUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialUsed",
                table: "MaterialUsed");

            migrationBuilder.DropIndex(
                name: "IX_MaterialUsed_MaterialId",
                table: "MaterialUsed");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialUsedId",
                table: "MaterialUsed",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialUsed",
                table: "MaterialUsed",
                columns: new[] { "MaterialId", "SemiFinishedId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUsed_Material_MaterialId",
                table: "MaterialUsed",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                table: "MaterialUsed",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUsed_Material_MaterialId",
                table: "MaterialUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                table: "MaterialUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialUsed",
                table: "MaterialUsed");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialUsedId",
                table: "MaterialUsed",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialUsed",
                table: "MaterialUsed",
                column: "MaterialUsedId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialUsed_MaterialId",
                table: "MaterialUsed",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUsed_Material_MaterialId",
                table: "MaterialUsed",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialUsed_SemiFinished_SemiFinishedId",
                table: "MaterialUsed",
                column: "SemiFinishedId",
                principalTable: "SemiFinished",
                principalColumn: "SemiFinishedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
