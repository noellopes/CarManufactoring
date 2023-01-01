using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class OrderStateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStateId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    OrderStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStateName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.OrderStateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateId",
                table: "Order",
                column: "OrderStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order",
                column: "OrderStateId",
                principalTable: "OrderState",
                principalColumn: "OrderStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderStateId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderStateId",
                table: "Order");
        }
    }
}
