using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDS.Migrations.Migrations
{
    public partial class Add_StoreRoleToEmployeeManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_StoreRole_StoreRoleID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_StoreRoleID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "StoreRoleID",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    EmployeePositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.EmployeePositionID);
                    table.ForeignKey(
                        name: "FK_EmployeePosition_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePosition_StoreRole_PositionID",
                        column: x => x.PositionID,
                        principalTable: "StoreRole",
                        principalColumn: "StoreRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePosition_EmployeeID",
                table: "EmployeePosition",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePosition_PositionID",
                table: "EmployeePosition",
                column: "PositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.AddColumn<int>(
                name: "StoreRoleID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_StoreRoleID",
                table: "Employee",
                column: "StoreRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_StoreRole_StoreRoleID",
                table: "Employee",
                column: "StoreRoleID",
                principalTable: "StoreRole",
                principalColumn: "StoreRoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
