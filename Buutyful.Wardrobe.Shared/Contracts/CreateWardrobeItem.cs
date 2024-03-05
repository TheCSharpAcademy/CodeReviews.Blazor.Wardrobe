using Buutyful.Wardrobe.Shared.Enums;

namespace Buutyful.Wardrobe.Shared.Contracts;

public record CreateWardrobeItem(
        Guid WardrobeId,
        string? ImgUrl,
        ClothingType ClothingType,
        string? Description);

