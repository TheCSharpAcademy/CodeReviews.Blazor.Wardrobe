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
public enum ClothingType
{
    A,
    B,
    C
}