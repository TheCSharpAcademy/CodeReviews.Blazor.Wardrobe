using Microsoft.EntityFrameworkCore;
using Wardrobe.Context;
using Wardrobe.Model;

namespace Wardrobe.Repository
{
    public class WardrobeRepository : IWardrobeRepository<WardrobeViewModel>
    {
        WardrobeContext _dbContext;
        public WardrobeRepository( WardrobeContext context ) 
        {
            _dbContext = context;
        }

        public async Task<WardrobeViewModel> CreateAsync( WardrobeViewModel entity )
        {
            var obj = await _dbContext.Clothes.AddAsync(entity);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public async Task DeleteAsync( int Id)
        {
            var data = _dbContext.Clothes.FirstOrDefault(x => x.Id == Id);
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WardrobeViewModel>> GetAllAsync()
        {
            return await _dbContext.Clothes.ToListAsync();
        }

        public async Task<WardrobeViewModel> GetByIdAsync( int Id )
        {
            return await _dbContext.Clothes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task UpdateAsync( WardrobeViewModel entity )
        {
            _dbContext.Clothes.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
