using Buutyful.Wardrobe.Shared.Enums;

namespace Buutyful.Wardrobe.Shared.Contracts;

public record WardrobeItemResponse(
        Guid Id,
        Guid WardrobeId,
        string? ImgUrl,
        ClothingType ClothingType,
        DateTime AddedAt,
        string? Description);