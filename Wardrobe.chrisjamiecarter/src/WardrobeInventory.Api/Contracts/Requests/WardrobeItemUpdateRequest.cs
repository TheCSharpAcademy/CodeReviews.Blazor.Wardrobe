using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Requests;

/// <summary>
/// Represents the data required to update an existing <see cref="WardrobeItem"/> in the Wardrobe Inventory application.
/// </summary>
public record WardrobeItemUpdateRequest(string Name, string? ImagePath, WardrobeItemColours? Colour, WardrobeItemMaterials? Material, WardrobeItemSizes? Size);
