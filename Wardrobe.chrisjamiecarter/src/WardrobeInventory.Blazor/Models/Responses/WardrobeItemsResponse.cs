namespace WardrobeInventory.Blazor.Models.Responses;

/// <summary>
/// Represents a response model for retrieving wardrobe items, extending the base response to include a collection of wardrobe item data transfer objects.
/// </summary>
public class WardrobeItemsResponse : BaseResponse
{
    public IReadOnlyList<WardrobeItemDto>? WardrobeItems { get; set; }
}
