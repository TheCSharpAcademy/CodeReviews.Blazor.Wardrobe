using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.WardrobeInventory.Server.Migrations;

public partial class mssqllocal_migration_554 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "ImagePath",
            table: "WardrobeItem",
            newName: "ImgData");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "ImgData",
            table: "WardrobeItem",
            newName: "ImagePath");
    }
}
