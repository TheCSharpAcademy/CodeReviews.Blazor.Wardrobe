using Wardrobe.frockett.api.DTOs;
using Wardrobe.frockett.api.Models;

namespace Wardrobe.frockett.Repository;

public interface IClosetRepository
{
    Task<IEnumerable<ItemDto>> GetAllItemsAsync();
    Task<ItemDto> GetItemByIdAsync(int id);
    Task<ClothingItem> AddItemAsync(ItemDto item, IFormFile? image);
    Task<ClothingItem> UpdateItemAsync(ItemDto item, IFormFile? image);
    Task<bool> DeleteItemAsync(int id);
}