namespace WardrobeInventory.Entities;

/// <summary>
/// Represents the base entity for all database models in the Wardrobe Inventory application.
/// This class provides a common identifier property (<see cref="Id"/>) 
/// to ensure consistency across derived entities.
/// </summary>
public class BaseEntity
{
    public required Guid Id { get; set; }
}
