using WardrobeInventory.Entities;

namespace WardrobeInventory.Repositories;

/// <summary>
/// Defines a repository interface specifically for managing <see cref="WardrobeItem"/> entities 
/// in the Wardrobe Inventory application.
/// Inherits the generic CRUD operations from <see cref="IGenericRepository{WardrobeItem}"/>.
/// </summary>
public interface IWardrobeItemRepository : IGenericRepository<WardrobeItem>
{
}