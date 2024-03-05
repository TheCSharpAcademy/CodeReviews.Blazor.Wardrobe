using Buutyful.Wardrobe.Shared.Contracts;
using Buutyful.Wardrobe.Shared.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Buutyful.Wardrobe.Models;

public class WardrobeItem
{
    private WardrobeItem() { } //ef ctor
    public Guid Id { get; private set; }
    public Guid WardrobeId { get; private set; }
    public string? ImgUrl { get; private set; }
    public ClothingType ClothingType { get; private set; }
    public DateTime AddedAt { get; private set; }
    public string? Description { get; private set; }

    public WardrobeItem(
        Guid wardrobeId,
        string? imgUrl,
        ClothingType clothingType,       
        string? description)
    {       
        WardrobeId = wardrobeId;
        ImgUrl = imgUrl;
        ClothingType = clothingType;
        AddedAt = DateTime.UtcNow;
        Description = description;
    }
}
public static class WardrobeItemExtentions
{
    public static WardrobeItemResponse MapToResponse(this WardrobeItem item) =>
        new(item.Id,
            item.WardrobeId,
            item.ImgUrl,
            item.ClothingType,
            item.AddedAt,
            item.Description);
    public static List<WardrobeItemResponse> MapToResponseList(this IEnumerable<WardrobeItem> source) =>
        source.Select(MapToResponse).ToList();
    public static WardrobeItem CreateFromRequest(this CreateWardrobeItem item) =>
        new(item.WardrobeId,
            item.ImgUrl,
            item.ClothingType,
            item.Description);
}