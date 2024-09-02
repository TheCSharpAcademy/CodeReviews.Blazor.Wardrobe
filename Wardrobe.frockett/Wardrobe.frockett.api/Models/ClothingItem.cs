namespace Wardrobe.frockett.api.Models;

public class ClothingItem
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public byte[]? ImageData { get; set; }

}
