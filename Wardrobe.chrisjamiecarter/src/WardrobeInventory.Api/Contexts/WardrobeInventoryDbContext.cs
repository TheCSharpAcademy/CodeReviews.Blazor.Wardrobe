using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Entities;

namespace WardrobeInventory.Api.Contexts;

/// <summary>
/// Represents the Entity Framework database context for the Wardrobe Inventory application.
/// Provides access to the application's database tables and configures entity relationships and constraints.
/// </summary>
/// <param name="options">
/// The <see cref="DbContextOptions{WardrobeInventoryDbContext}"/> used to configure the database context.
/// </param>
public class WardrobeInventoryDbContext(DbContextOptions<WardrobeInventoryDbContext> options) : DbContext(options)
{
    public DbSet<WardrobeItem> WardrobeItems { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WardrobeItem>().ToTable(nameof(WardrobeItem));
        modelBuilder.Entity<WardrobeItem>().HasKey(x => x.Id);
        modelBuilder.Entity<WardrobeItem>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<WardrobeItem>().Property(p => p.ImagePath).IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
