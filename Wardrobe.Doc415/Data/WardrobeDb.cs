using Microsoft.EntityFrameworkCore;
using Wardrobe.Doc415.Models;

namespace Wardrobe.Doc415.Data;

public class WardrobeDb: DbContext
{
    public WardrobeDb (DbContextOptions<WardrobeDb> options) : base(options) { }

    public DbSet<Cloth> Clothes { get; set; }
}
