using Wardrobe.BBualdo.Models;

namespace Wardrobe.BBualdo.Services;

public interface IWardrobeService
{
    Task<List<Cloth>> GetClothes();
    Task AddCloth(NewClothDto cloth);
    Task UpdateCloth(Cloth cloth);
    Task DeleteCloth(Cloth cloth);
}