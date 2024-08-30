using Wardrobe.frockett.wasm.Models;
public interface IClothingRepository
{
    Task<List<ClothingItem>> GetAllClothingItemsAsync();
    Task<ClothingItem> GetClothingItemByIdAsync(int id);
    Task AddClothingItemAsync(ClothingItem item);
    Task UpdateClothingItemAsync(ClothingItem item);
    Task DeleteClothingItemAsync(int id);
}