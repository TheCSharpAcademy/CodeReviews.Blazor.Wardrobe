using Microsoft.EntityFrameworkCore;
using Wardrobe.BBualdo.Data;
using Wardrobe.BBualdo.Models;

namespace Wardrobe.BBualdo.Services;

public class WardrobeService(AppDbContext dbContext):IWardrobeService
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<List<Cloth>> GetClothes()
    {
        return await _dbContext.Clothes.ToListAsync();
    }

    public async Task AddCloth(NewClothDto newCloth)
    {
        Cloth cloth = new()
        {
            Name = newCloth.Name,
            Category = newCloth.Category,
            Color = newCloth.Color,
            Brand = newCloth.Brand,
            Size = newCloth.Size,
            ImagePath = newCloth.ImagePath
        };
        
        await _dbContext.Clothes.AddAsync(cloth);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCloth(Cloth cloth)
    {
        _dbContext.Entry(cloth).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCloth(Cloth cloth)
    {
        _dbContext.Clothes.Remove(cloth);
        await _dbContext.SaveChangesAsync();
    }
}