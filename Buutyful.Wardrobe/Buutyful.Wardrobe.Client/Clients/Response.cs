using System.Net;
using System.Text.Json;

namespace Buutyful.Wardrobe.Client.Clients;

public static class Response
{
    public static async Task<T> Handle<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }

    public static async Task<List<T>> HandleList<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<T>>(content) ?? [];
    }
    public static bool HandleResult(HttpResponseMessage response) =>
        response.IsSuccessStatusCode;

}
