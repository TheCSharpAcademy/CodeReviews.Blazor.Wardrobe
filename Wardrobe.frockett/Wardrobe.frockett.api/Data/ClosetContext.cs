using Microsoft.EntityFrameworkCore;
using Wardrobe.frockett.api.Models;

namespace Wardrobe.frockett.api.Data;

public class ClosetContext : DbContext
{
    public ClosetContext(DbContextOptions<ClosetContext> options) : base(options) { }

    public DbSet<ClothingItem> ClothingItems { get; set; }
}