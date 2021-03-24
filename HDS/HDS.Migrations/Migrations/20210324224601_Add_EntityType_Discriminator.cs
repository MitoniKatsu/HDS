using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDS.Migrations.Migrations
{
    public partial class Add_EntityType_Discriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntityTypeID",
                table: "EntityAddress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntityType",
                columns: table => new
                {
                    EntityTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.EntityTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityAddress_EntityTypeID",
                table: "EntityAddress",
                column: "EntityTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress",
                column: "EntityTypeID",
                principalTable: "EntityType",
                principalColumn: "EntityTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.InsertData(
                table: "EntityType",
                columns: new[] { "EntityTypeName" },
                values: new object[] { "Customer" });
            migrationBuilder.InsertData(
                table: "EntityType",
                columns: new[] { "EntityTypeName" },
                values: new object[] { "Employee" });
            migrationBuilder.InsertData(
                table: "EntityType",
                columns: new[] { "EntityTypeName" },
                values: new object[] { "Store" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress");

            migrationBuilder.DropTable(
                name: "EntityType");

            migrationBuilder.DropIndex(
                name: "IX_EntityAddress_EntityTypeID",
                table: "EntityAddress");

            migrationBuilder.DropColumn(
                name: "EntityTypeID",
                table: "EntityAddress");
        }
    }
}
