using Microsoft.EntityFrameworkCore;
using Wardrobe.frockett.api.Models;
using Wardrobe.frockett.api.Data;
using Wardrobe.frockett.Repository;

namespace Wardrobe.frockett.api.Repository;

public class ClosetRepository : IClosetRepository
{
    private readonly ClosetContext _context;

    public ClosetRepository(ClosetContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClothingItem>> GetAllItemsAsync()
    {
        return await _context.ClothingItems.ToListAsync();
    }

    public async Task<ClothingItem> GetItemByIdAsync(int id)
    {
        return await _context.ClothingItems.FindAsync(id);
    }

    public async Task<ClothingItem> AddItemAsync(ClothingItem item, IFormFile? image)
    {
        
        if (image != null && image.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                item.ImageData = base64String;
            }
        }

        _context.ClothingItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<ClothingItem> UpdateItemAsync(ClothingItem item, IFormFile? image)
    {
        var existingItem = await _context.ClothingItems.FindAsync(item.Id);
        if (existingItem == null)
            return null;

        if (image != null && image.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                item.ImageData = base64String;
            }
        }
        else
        {
            if (existingItem.ImageData != null)
                item.ImageData = existingItem.ImageData;
        }

        _context.Entry(existingItem).CurrentValues.SetValues(item);
        await _context.SaveChangesAsync();
        return existingItem;
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var item = await _context.ClothingItems.FindAsync(id);
        if (item == null)
            return false;

        _context.ClothingItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}