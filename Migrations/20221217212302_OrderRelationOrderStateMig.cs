using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManufactoring.Migrations
{
    public partial class OrderRelationOrderStateMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStateId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order",
                column: "OrderStateId",
                principalTable: "OrderState",
                principalColumn: "OrderStateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStateId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OrderState",
                table: "Order",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderState_OrderStateId",
                table: "Order",
                column: "OrderStateId",
                principalTable: "OrderState",
                principalColumn: "OrderStateId");
        }
    }
}
