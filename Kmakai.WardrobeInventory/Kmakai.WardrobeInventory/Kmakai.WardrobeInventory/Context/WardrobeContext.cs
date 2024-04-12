using Microsoft.EntityFrameworkCore;
using Shared.Models;
namespace Kmakai.WardrobeInventory.Context;

public class WardrobeContext: DbContext
{
    public WardrobeContext(DbContextOptions<WardrobeContext> options): base(options)
    {
    }

    public DbSet<WardrobeItem> WardrobeItems { get; set; }
    public DbSet<Wardrobe> wardrobes { get; set; }
    public DbSet<WardrobeImage> wardrobeImages { get; set;}

}
