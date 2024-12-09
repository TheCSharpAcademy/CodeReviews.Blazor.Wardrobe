namespace WardrobeInventory.Blazor.Models.Responses;

/// <summary>
/// Represents a response model for retrieving an image file, extending the base response to include an image path value.
/// </summary>
public class ImageFileResponse : BaseResponse
{
    public string? ImagePath { get; set; }
}
