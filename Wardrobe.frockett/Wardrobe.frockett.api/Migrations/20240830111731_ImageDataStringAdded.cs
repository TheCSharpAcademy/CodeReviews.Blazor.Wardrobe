using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wardrobe.frockett.api.Migrations
{
    /// <inheritdoc />
    public partial class ImageDataStringAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ClothingItems");

            migrationBuilder.AddColumn<string>(
                name: "ImageData",
                table: "ClothingItems",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ClothingItems");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ClothingItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
