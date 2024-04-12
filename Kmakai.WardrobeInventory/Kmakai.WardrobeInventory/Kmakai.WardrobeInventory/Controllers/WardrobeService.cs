using Kmakai.WardrobeInventory.Context;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Kmakai.WardrobeInventory.Controllers;

public class WardrobeService
{
    private readonly WardrobeContext _context;
    public WardrobeService(WardrobeContext context)
    {
        _context = context;
    }

    public async Task<Wardrobe?> GetWardrobe(int id)
    {
        return await _context.wardrobes.Include(w => w.Footwear).ThenInclude(f => f.Image)
            .Include(w => w.Bottom).ThenInclude(b => b.Image).Include(w => w.Top).ThenInclude(t => t.Image).FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<List<Wardrobe>> GetWardrobes()
    {
        return await _context.wardrobes.Include(w => w.Footwear).ThenInclude(f => f.Image)
            .Include(w => w.Bottom).ThenInclude(b => b.Image).Include(w => w.Top).ThenInclude(t => t.Image).ToListAsync();
    }

    public async Task<Wardrobe> CreateWardrobe(Wardrobe wardrobe)
    {
        _context.wardrobes.Add(wardrobe);
        await _context.SaveChangesAsync();
        return wardrobe;
    }

    public async Task<Wardrobe> UpdateWardrobe(Wardrobe wardrobe)
    {
        _context.Entry(wardrobe).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return wardrobe;
    }

    public async Task DeleteWardrobe(int id)
    {
        var wardrobe = await _context.wardrobes.FindAsync(id);
        _context.wardrobes.Remove(wardrobe);
        await _context.SaveChangesAsync();
    }

    public async Task<WardrobeItem> AddItem(WardrobeItem item)
    {
        _context.WardrobeItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<WardrobeItem> UpdateItem(WardrobeItem item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task DeleteItem(int id)
    {
        var item = await _context.WardrobeItems.FindAsync(id);
        _context.WardrobeItems.Remove(item);
        await _context.SaveChangesAsync();
    }


    public async Task<WardrobeItem?> GetItem(int id)
    {
        var item = await _context.WardrobeItems.Include(i => i.Image).FirstOrDefaultAsync(i => i.Id == id);
        return item;
    }


    public async Task<List<WardrobeItem>> GetItems()
    {
        return await _context.WardrobeItems.Include(i => i.Image).ToListAsync();
    }

   
    public async Task<bool> UploadImage(IFormFile file, int id)
    {
        var item = _context.WardrobeItems.Find(id);

        if (item == null)
        {
            return false;
        }

        if (file == null || file.Length == 0)
        {
            Console.WriteLine("File is empty");
            return false;

        }

        try
        {
            var extension = Path.GetExtension(file.Name);

            Console.WriteLine(extension);
            var fileName = Path.GetFileName(file.Name);
            Console.WriteLine(fileName);
            var path = Path.Combine("wwwroot", "images", $"{item.Id}-{fileName}");
            await using var stream = new FileStream(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(stream);

            var image = new WardrobeImage
            {
                ImageUrl = $"images/{item.Id}-{fileName}",
            };

            if (image != null)
            {
                _context.wardrobeImages.Add(image);
                await _context.SaveChangesAsync();
            }

            item.ImageId = image?.Id;
            await UpdateItem(item);

            return true;


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }


    }

    public async Task<bool> HandleImageUpload(IFormFile file)
    {
        try
        {
            var extension = Path.GetExtension(file.Name);
            Console.WriteLine($"The extension is: {file.ContentType} ----------");
            var fileName = Path.GetFileName(file.Name);
            var path = Path.Combine("wwwroot", "images", fileName);
            await using var stream = new FileStream(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(stream);

            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }


    }

    public async Task<WardrobeImage?> GetImage(int id)
    {
        return await _context.wardrobeImages.FindAsync(id);
    }


}
