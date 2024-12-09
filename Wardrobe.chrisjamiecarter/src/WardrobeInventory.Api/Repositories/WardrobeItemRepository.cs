using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Repositories;

/// <summary>
/// Provides repository operations specifically for <see cref="WardrobeItem"/> entities in the Wardrobe Inventory application.
/// </summary>
public class WardrobeItemRepository(WardrobeInventoryDbContext context) : GenericRepository<WardrobeItem>(context), IWardrobeItemRepository
{
}
