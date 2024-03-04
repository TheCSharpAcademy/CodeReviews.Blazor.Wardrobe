using Microsoft.EntityFrameworkCore;
using Wardrobe.Doc415.Models;
using Wardrobe.Doc415.Data;
using SqliteWasmHelper;

namespace Wardrobe.Doc415;

public class WardrobeController
{

  
    private readonly ISqliteWasmDbContextFactory<WardrobeDb> _DbFactory;

    public WardrobeController (ISqliteWasmDbContextFactory<WardrobeDb> factory)
    {
        _DbFactory = factory;
    }

    public async Task<List<Cloth>> GetAllClothes ()
    {
        using var _context=await _DbFactory.CreateDbContextAsync ();
        return await _context.Clothes.ToListAsync();
    }

    public async Task<Cloth> GetClothById(int id)
    {
        using var _context = await _DbFactory.CreateDbContextAsync();
        return await _context.Clothes.SingleAsync(x => x.Id == id);
    }

    public async Task DeleteCloth(int id)
    {
        using var _context = await _DbFactory.CreateDbContextAsync();
        var cloth=await _context.Clothes.SingleAsync(x=> x.Id == id);
        _context.Clothes.Remove(cloth);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCloth(Cloth cloth)
    {
        using var _context = await _DbFactory.CreateDbContextAsync();
        var toUpdate=await _context.Clothes.SingleAsync(x=> x.Id==cloth.Id);
        toUpdate.Weather=cloth.Weather;
        toUpdate.Color=cloth.Color;
        toUpdate.Category=cloth.Category;
        toUpdate.Name=cloth.Name;
        toUpdate.ImageUrl=cloth.ImageUrl;

        _context.Clothes.Update(toUpdate);
        await _context.SaveChangesAsync();
    }

    public async Task AddCloth(Cloth cloth)
    {
        using var _context = await _DbFactory.CreateDbContextAsync();
        _context.Clothes.Add(cloth);
        await _context.SaveChangesAsync();
    }
}
