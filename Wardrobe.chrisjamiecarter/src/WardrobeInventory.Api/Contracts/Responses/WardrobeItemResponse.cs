using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Contracts.Responses;

/// <summary>
/// Represents the response data for a <see cref="WardrobeItem"/> in the Wardrobe Inventory application.
/// </summary>
public record WardrobeItemResponse(Guid Id, string Name, string ImagePath, WardrobeItemColours? Colour, WardrobeItemMaterials? Material, WardrobeItemSizes? Size);
