using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobe.Doc415.Models;

public class Cloth
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string Category { get; set; }


    public string Color { get; set; }
    public string Weather { get; set; }
    public string ImageUrl { get; set; }
}
