using System;
using Wardrobe.Model;
using Wardrobe.Repository;

namespace Wardrobe.Service
{
    public class WardrobeService : IWardrobeService
    {
        private readonly IWardrobeRepository<WardrobeViewModel> _repository;

        public WardrobeService( IWardrobeRepository<WardrobeViewModel> repository )
        {
            _repository = repository;
        }

        public async Task<WardrobeViewModel> AddClothe( WardrobeViewModel viewModel )
        {
            return await _repository.CreateAsync(viewModel);
        }

        public async Task<bool> DeleteClothe( int id )
        {
            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<List<WardrobeViewModel>> GetAllClothes()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WardrobeViewModel> GetClothe( int id )
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateClothe( int id, WardrobeViewModel viewModel )
        {
            var data = await _repository.GetByIdAsync(id);
            if (data != null)
            {
                data.Name = viewModel.Name;
                data.Color = viewModel.Color;

                await _repository.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }
    }
}
