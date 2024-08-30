using Wardrobe.frockett.api.Models;

namespace Wardrobe.frockett.Repository;

public interface IClosetRepository
{
    Task<IEnumerable<ClothingItem>> GetAllItemsAsync();
    Task<ClothingItem> GetItemByIdAsync(int id);
    Task<ClothingItem> AddItemAsync(ClothingItem item, IFormFile? image);
    Task<ClothingItem> UpdateItemAsync(ClothingItem item, IFormFile? image);
    Task<bool> DeleteItemAsync(int id);
}