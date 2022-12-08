using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class correctSectionsMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "SectionManager",
                columns: table => new
                {
                    SectionManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionManager", x => x.SectionManagerId);
                    table.ForeignKey(
                        name: "FK_SectionManager_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

       



            migrationBuilder.CreateIndex(
                name: "IX_SectionManager_SectionId",
                table: "SectionManager",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
  

            migrationBuilder.DropTable(
                name: "SectionManager");

     
        }
    }
}
