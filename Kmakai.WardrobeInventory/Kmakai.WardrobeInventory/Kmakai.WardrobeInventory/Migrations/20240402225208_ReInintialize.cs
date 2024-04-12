using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kmakai.WardrobeInventory.Migrations
{
    /// <inheritdoc />
    public partial class ReInintialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wardrobeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wardrobeImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WardrobeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardrobeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WardrobeItems_wardrobeImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "wardrobeImages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wardrobes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopId = table.Column<int>(type: "int", nullable: true),
                    BottomId = table.Column<int>(type: "int", nullable: true),
                    FootwearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wardrobes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wardrobes_WardrobeItems_BottomId",
                        column: x => x.BottomId,
                        principalTable: "WardrobeItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wardrobes_WardrobeItems_FootwearId",
                        column: x => x.FootwearId,
                        principalTable: "WardrobeItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wardrobes_WardrobeItems_TopId",
                        column: x => x.TopId,
                        principalTable: "WardrobeItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WardrobeItems_ImageId",
                table: "WardrobeItems",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_wardrobes_BottomId",
                table: "wardrobes",
                column: "BottomId");

            migrationBuilder.CreateIndex(
                name: "IX_wardrobes_FootwearId",
                table: "wardrobes",
                column: "FootwearId");

            migrationBuilder.CreateIndex(
                name: "IX_wardrobes_TopId",
                table: "wardrobes",
                column: "TopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wardrobes");

            migrationBuilder.DropTable(
                name: "WardrobeItems");

            migrationBuilder.DropTable(
                name: "wardrobeImages");
        }
    }
}
