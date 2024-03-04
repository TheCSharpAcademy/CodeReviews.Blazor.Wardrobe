namespace Buutyful.Wardrobe.Models;

public class Wardrobe
{
    private Wardrobe() { } //ef ctor
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public List<WardrobeItem> Items { get; private set; } = [];
    public Wardrobe(string name, string? description)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description;
    }

}

