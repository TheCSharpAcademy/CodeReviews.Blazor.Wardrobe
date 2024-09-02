using Microsoft.EntityFrameworkCore;
using Wardrobe.frockett.api.Models;
using Wardrobe.frockett.api.Data;
using Wardrobe.frockett.Repository;
using Wardrobe.frockett.api.DTOs;
using System.Runtime.CompilerServices;

namespace Wardrobe.frockett.api.Repository;

public class ClosetRepository : IClosetRepository
{
    private readonly ClosetContext _context;

    public ClosetRepository(ClosetContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
    {
        var items = await _context.ClothingItems.ToListAsync();
        return ConvertToDto(items);
    }

    public async Task<ItemDto> GetItemByIdAsync(int id)
    {
        var item = await _context.ClothingItems.FindAsync(id);
        return ConvertSingleItemDto(item);
    }

    private List<ItemDto> ConvertToDto(List<ClothingItem> clothingItems)
    {
        return clothingItems.Select(item => ConvertSingleItemDto(item)).ToList();
    }

    private ItemDto ConvertSingleItemDto(ClothingItem item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Type = item.Type,
            ImageData = item.ImageData != null ? Convert.ToBase64String(item.ImageData) : null
        };
    }

    private ClothingItem ConvertToDomainModel(ItemDto dto)
    {
        return new ClothingItem
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
        };
    }

    public async Task<ClothingItem> AddItemAsync(ItemDto item, IFormFile? image)
    {

        ClothingItem newItem = ConvertToDomainModel(item);

        if (image != null && image.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                newItem.ImageData = memoryStream.ToArray();
            }
        }

        _context.ClothingItems.Add(newItem);
        await _context.SaveChangesAsync();
        return newItem;
    }

    public async Task<ClothingItem> UpdateItemAsync(ItemDto item, IFormFile? image)
    {
        var existingItem = await _context.ClothingItems.FindAsync(item.Id);
        if (existingItem == null)
            return null;

        ClothingItem itemToUpdate = ConvertToDomainModel(item);

        if (image != null && image.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                itemToUpdate.ImageData = memoryStream.ToArray();
            }
        }
        else
        {
            if (existingItem.ImageData != null)
                itemToUpdate.ImageData = existingItem.ImageData;
        }

        _context.Entry(existingItem).CurrentValues.SetValues(itemToUpdate);
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