using Microsoft.EntityFrameworkCore.Migrations;

namespace HDS.Migrations.Migrations
{
    public partial class Add_StoreLocationToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationID",
                table: "Inventory",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Store_LocationID",
                table: "Inventory",
                column: "LocationID",
                principalTable: "Store",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Store_LocationID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_LocationID",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Inventory");
        }
    }
}
