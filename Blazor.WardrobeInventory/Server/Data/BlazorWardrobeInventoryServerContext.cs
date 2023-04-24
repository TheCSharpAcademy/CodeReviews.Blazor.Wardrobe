using Microsoft.EntityFrameworkCore;

namespace Blazor.WardrobeInventory.Server.Data;

public class BlazorWardrobeInventoryServerContext : DbContext
{
    public BlazorWardrobeInventoryServerContext (DbContextOptions<BlazorWardrobeInventoryServerContext> options)
        : base(options)
    {
    }

    public DbSet<Blazor.WardrobeInventory.Shared.Models.WardrobeItem> WardrobeItem { get; set; } = default!;
}
