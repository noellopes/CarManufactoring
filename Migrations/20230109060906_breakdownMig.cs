using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class breakdownMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MachineReplacement",
                table: "Breakdown",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "RepairInTheCompany",
                table: "Breakdown",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "WorkerPunctuality",
                columns: table => new
                {
                    WorkerPunctualityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerCollaboratorId = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    MissedHoursLastWeek = table.Column<int>(type: "int", nullable: false),
                    LateShiftsLastWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPunctuality", x => x.WorkerPunctualityId);
                    table.ForeignKey(
                        name: "FK_WorkerPunctuality_Collaborator_WorkerCollaboratorId",
                        column: x => x.WorkerCollaboratorId,
                        principalTable: "Collaborator",
                        principalColumn: "CollaboratorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPunctuality_WorkerCollaboratorId",
                table: "WorkerPunctuality",
                column: "WorkerCollaboratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerPunctuality");

            migrationBuilder.DropColumn(
                name: "RepairInTheCompany",
                table: "Breakdown");

            migrationBuilder.AlterColumn<string>(
                name: "MachineReplacement",
                table: "Breakdown",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
