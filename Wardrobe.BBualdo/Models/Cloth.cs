using System.ComponentModel.DataAnnotations;

namespace Wardrobe.BBualdo.Models;

public class Cloth
{
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    public required string Name { get; set; }

    public required string Category { get; set; }
    public required string Size { get; set; }

    [Required]
    [MinLength(4, ErrorMessage = "Name must be at least 4 characters long.")]
    [StringLength(20, ErrorMessage = "Name can't be longer than 20 characters.")]
    public required string Color { get; set; }

    [Required] public required string Brand { get; set; }
    public string? ImagePath { get; set; }
}