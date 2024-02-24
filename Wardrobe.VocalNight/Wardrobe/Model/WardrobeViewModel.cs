using System.ComponentModel.DataAnnotations;

namespace Wardrobe.Model
{
    public class WardrobeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string ImagePath {  get; set; }
    }
}
