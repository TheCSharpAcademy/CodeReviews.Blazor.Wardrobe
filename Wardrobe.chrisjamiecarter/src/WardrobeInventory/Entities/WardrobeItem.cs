using WardrobeInventory.Enums;

namespace WardrobeInventory.Entities;

/// <summary>
/// Represents a wardrobe item entity in the Wardrobe Inventory application.
/// Inherits from <see cref="BaseEntity"/> and includes properties specific to wardrobe items, 
/// such as name, image path, color, material, and size.
/// </summary>
public class WardrobeItem : BaseEntity
{
    public required string Name { get; set; }

    public string ImagePath { get; set; } = "/img/B5FCD8C6-66E8-4F42-97C8-B6921C8DEC30.png";

    public WardrobeItemColours? Colour { get; set; }

    public WardrobeItemMaterials? Material { get; set; }

    public WardrobeItemSizes? Size { get; set; }
}
