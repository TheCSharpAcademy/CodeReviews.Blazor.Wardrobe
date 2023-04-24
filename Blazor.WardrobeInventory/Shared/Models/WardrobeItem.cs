using System.ComponentModel.DataAnnotations;

namespace Blazor.WardrobeInventory.Shared.Models;

public class WardrobeItem
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Color { get; set; }
    [Required(ErrorMessage = "The Image is required.")]
    public string ImgData { get; set; }
}
