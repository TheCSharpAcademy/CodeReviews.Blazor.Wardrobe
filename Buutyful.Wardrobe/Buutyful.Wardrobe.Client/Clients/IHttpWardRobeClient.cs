using Buutyful.Wardrobe.Shared.Contracts;

namespace Buutyful.Wardrobe.Client.Clients;

public interface IHttpWardRobeClient
{
    Task<List<WardrobeItemResponse>> GetAsync();
    Task<WardrobeItemResponse> GetByIdAsync(Guid id);
    Task<WardrobeItemResponse> CreateAsync(CreateWardrobeItem wardrobeItem);
    Task<bool> UpdateAsync(Guid id, UpdateWardrobeItem wardrobeItem);
    Task<bool> DeleteAsync(Guid id);
}
