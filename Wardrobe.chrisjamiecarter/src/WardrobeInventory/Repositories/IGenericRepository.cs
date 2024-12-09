using WardrobeInventory.Entities;

namespace WardrobeInventory.Repositories;

/// <summary>
/// Defines a generic repository interface for managing entities in the Wardrobe Inventory application.
/// Provides CRUD operations for entities that inherit from <see cref="BaseEntity"/>.
/// </summary>
/// <typeparam name="T">
/// The type of entity being managed, constrained to types derived from <see cref="BaseEntity"/>.
/// </typeparam>
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<bool> CreateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<IReadOnlyList<T>> ReturnAsync();
    Task<T?> ReturnAsync(Guid id);
    Task<bool> UpdateAsync(T entity);
}