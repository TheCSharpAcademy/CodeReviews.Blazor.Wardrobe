using Microsoft.EntityFrameworkCore;
using Wardrobe.frockett.Models;

namespace Wardrobe.frockett.Data;

public class ClosetDbContext : DbContext
{
    public ClosetDbContext(DbContextOptions<ClosetDbContext> options) : base(options) { }

    public DbSet<ClothingItem> ClothingItems { get; set; }
}