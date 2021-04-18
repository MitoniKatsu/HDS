using Microsoft.EntityFrameworkCore.Migrations;

namespace HDS.Migrations.Migrations
{
    public partial class AddServiceOrderIDColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Order_OrderID",
                table: "Service");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Order_OrderID",
                table: "Service",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Order_OrderID",
                table: "Service");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Service",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Order_OrderID",
                table: "Service",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
