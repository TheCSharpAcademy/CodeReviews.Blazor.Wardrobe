using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Requests;

/// <summary>
/// Represents the data required to create a new <see cref="WardrobeItem"/> in the Wardrobe Inventory application.
/// </summary>
public record WardrobeItemCreateRequest(string Name, string? ImagePath, WardrobeItemColours? Colour, WardrobeItemMaterials? Material, WardrobeItemSizes? Size);
