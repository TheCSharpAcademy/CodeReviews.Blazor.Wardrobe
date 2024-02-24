using Wardrobe.Model;

namespace Wardrobe.Service
{
    public interface IWardrobeService
    {
        Task<WardrobeViewModel> AddClothe(WardrobeViewModel viewModel);
        Task<bool> UpdateClothe(int id, WardrobeViewModel viewModel);
        Task<bool> DeleteClothe(int id);
        Task<List<WardrobeViewModel>> GetAllClothes();
        Task<WardrobeViewModel> GetClothe(int id);
    }
}
