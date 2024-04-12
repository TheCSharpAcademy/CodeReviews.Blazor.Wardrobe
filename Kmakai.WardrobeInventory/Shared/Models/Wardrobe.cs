namespace Shared.Models;

public class Wardrobe
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? TopId { get; set; }
    public int? BottomId { get; set; }
    public int? FootwearId { get; set; }
    public WardrobeItem? Top { get; set;}
    public WardrobeItem? Bottom { get; set; }
    public WardrobeItem? Footwear { get; set; }

}
