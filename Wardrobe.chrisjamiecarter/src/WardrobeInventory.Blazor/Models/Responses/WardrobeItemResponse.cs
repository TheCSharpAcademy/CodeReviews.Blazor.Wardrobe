namespace WardrobeInventory.Blazor.Models.Responses;

/// <summary>
/// Represents a response model for retrieving a wardrobe item, extending the base response to include a wardrobe item data transfer object.
/// </summary>
public class WardrobeItemResponse : BaseResponse
{
    public WardrobeItemDto? WardrobeItem { get; set; }
}
