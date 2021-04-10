using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;

namespace HDS.Migrations.Migrations
{
    public partial class SeedTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlPath;
            // AddressType
            sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "AddressType.Seed.Sql");
            migrationBuilder.Sql(File.ReadAllText(sqlPath), true);
            // ContactMethodType
            sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "ContactMethodType.Seed.Sql");
            migrationBuilder.Sql(File.ReadAllText(sqlPath), true);
            // EntityType
            sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "EntityType.Seed.Sql");
            migrationBuilder.Sql(File.ReadAllText(sqlPath), true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
