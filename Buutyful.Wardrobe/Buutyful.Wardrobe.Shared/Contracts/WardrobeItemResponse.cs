using Buutyful.Wardrobe.Shared.Enums;
using System.Text.Json.Serialization;

namespace Buutyful.Wardrobe.Shared.Contracts;


public class WardrobeItemResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    [JsonPropertyName("wardrobeId")]
    public Guid WardrobeId { get; init; }

    [JsonPropertyName("imgUrl")]
    public string? ImgUrl { get; init; }

    [JsonPropertyName("clothingType")]
    public ClothingType ClothingType { get; init; }

    [JsonPropertyName("addedAt")]
    public DateTime AddedAt { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    public WardrobeItemResponse(
        Guid id,
        Guid wardrobeId,
        string? imgUrl,
        ClothingType clothingType,
        DateTime addedAt,
        string? description)
    {
        Id = id;
        WardrobeId = wardrobeId;
        ImgUrl = imgUrl;
        ClothingType = clothingType;
        AddedAt = addedAt;
        Description = description;
    }
}