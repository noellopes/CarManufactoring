using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "WorkerPunctuality");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WorkerPunctuality",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "WorkerPunctuality",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WorkerPunctuality");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "WorkerPunctuality");

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "WorkerPunctuality",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
