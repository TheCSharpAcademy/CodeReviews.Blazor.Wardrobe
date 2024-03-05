using Buutyful.Wardrobe.Shared.Enums;

namespace Buutyful.Wardrobe.Client.Models;

public class CreateFromModel
{
    public Guid WardrobeId { get; set; }
    public string? ImgUrl { get; set; }
    public ClothingType ClothingType { get; set; }
    public string? Description { get; set; }
}
