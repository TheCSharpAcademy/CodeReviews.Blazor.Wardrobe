using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Entities;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Repositories;

/// <summary>
/// Provides a generic implementation of repository operations for entities in the Wardrobe Inventory application.
/// This class handles CRUD operations for any entity that derives from <see cref="BaseEntity"/>.
/// </summary>
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    public readonly WardrobeInventoryDbContext _context;

    public GenericRepository(WardrobeInventoryDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Entities => _context.Set<T>();

    public async Task<bool> CreateAsync(T entity)
    {
        await Entities.AddAsync(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        Entities.Remove(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    public async Task<IReadOnlyList<T>> ReturnAsync()
    {
        return await Entities.ToListAsync();
    }

    public async Task<T?> ReturnAsync(Guid id)
    {
        return await Entities.FindAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        Entities.Update(entity);

        var result = await SaveChangesAsync();
        return result > 0;
    }

    private async Task<int> SaveChangesAsync()
    {
        try
        {
            var changes = await _context.SaveChangesAsync();
            return changes;
        }
        catch (Exception exception)
        {
            Trace.TraceWarning(exception.Message);
            return -1;
        }
    }
}
