namespace Shared.Models;

public class WardrobeItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }

    public int? ImageId { get; set; }
    public WardrobeImage? Image { get; set; }

    public ItemType? ItemType { get; set; }
}
