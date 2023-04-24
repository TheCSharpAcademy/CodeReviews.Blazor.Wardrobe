using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.WardrobeInventory.Server.Migrations;

public partial class mssqllocal_migration_141 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "WardrobeItem",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WardrobeItem", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "WardrobeItem");
    }
}
