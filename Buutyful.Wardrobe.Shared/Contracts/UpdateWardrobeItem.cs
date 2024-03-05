using Buutyful.Wardrobe.Shared.Enums;

namespace Buutyful.Wardrobe.Shared.Contracts;


public record UpdateWardrobeItem(
        Guid WardrobeId,
        string? ImgUrl,
        ClothingType ClothingType,
        string? Description);