namespace Wardrobe.Repository
{
    public interface IWardrobeRepository<T>
    {
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int Id);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int Id);
    }
}
