using Buutyful.Wardrobe.Shared.Contracts;
using System.Net.Http.Json;

namespace Buutyful.Wardrobe.Client.Clients;

public class HttpWardRobeClient(HttpClient http) : IHttpWardRobeClient
{
    private readonly HttpClient _http = http;
    public async Task<List<WardrobeItemResponse>> GetAllWardrobeItemsAsync()
    {
        var response = await _http.GetAsync("/api/WardrobeItem");
        return await Response.HandleList<WardrobeItemResponse>(response);
    }
    public async Task<WardrobeItemResponse> GetWardrobeItemByIdAsync(Guid id)
    {
        var response = await _http.GetAsync($"/api/WardrobeItem/{id}");
        return await Response.Handle<WardrobeItemResponse>(response);
    }
    public async Task<WardrobeItemResponse> CreateWardrobeItemAsync(CreateWardrobeItem wardrobeItem)
    {
        var response = await _http.PostAsJsonAsync("/api/WardrobeItem", wardrobeItem);
        return await Response.Handle<WardrobeItemResponse>(response);
    }

    public async Task<bool> UpdateWardrobeItemAsync(Guid id, UpdateWardrobeItem wardrobeItem)
    {
        var response = await _http.PutAsJsonAsync($"/api/WardrobeItem/{id}", wardrobeItem);
        return Response.HandleResult(response);
    }
    public async Task<bool> DeleteWardrobeItemAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"/api/WardrobeItem/{id}");
        return Response.HandleResult(response);
    }
}
