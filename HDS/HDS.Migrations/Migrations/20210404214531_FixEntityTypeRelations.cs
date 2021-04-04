using Microsoft.EntityFrameworkCore.Migrations;

namespace HDS.Migrations.Migrations
{
    public partial class FixEntityTypeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress");

            migrationBuilder.AlterColumn<int>(
                name: "EntityTypeID",
                table: "EntityAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityTypeID",
                table: "ContactMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ContactMethod_EntityTypeID",
                table: "ContactMethod",
                column: "EntityTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMethod_EntityType_EntityTypeID",
                table: "ContactMethod",
                column: "EntityTypeID",
                principalTable: "EntityType",
                principalColumn: "EntityTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress",
                column: "EntityTypeID",
                principalTable: "EntityType",
                principalColumn: "EntityTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMethod_EntityType_EntityTypeID",
                table: "ContactMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress");

            migrationBuilder.DropIndex(
                name: "IX_ContactMethod_EntityTypeID",
                table: "ContactMethod");

            migrationBuilder.DropColumn(
                name: "EntityTypeID",
                table: "ContactMethod");

            migrationBuilder.AlterColumn<int>(
                name: "EntityTypeID",
                table: "EntityAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EntityAddress_EntityType_EntityTypeID",
                table: "EntityAddress",
                column: "EntityTypeID",
                principalTable: "EntityType",
                principalColumn: "EntityTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
