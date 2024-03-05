using Buutyful.Wardrobe.Shared.Enums;

namespace Buutyful.Wardrobe.Shared.Contracts;

public record WardrobeItemResponse(
        Guid Id,
        string? ImgUrl,
        ClothingType ClothingType,
        string? Description);