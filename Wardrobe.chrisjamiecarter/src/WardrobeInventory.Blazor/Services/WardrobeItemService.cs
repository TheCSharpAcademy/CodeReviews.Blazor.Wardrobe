using System.Text.Json;
using RestSharp;
using WardrobeInventory.Blazor.Extensions;
using WardrobeInventory.Blazor.Models;
using WardrobeInventory.Blazor.Models.Responses;

namespace WardrobeInventory.Blazor.Services;

/// <summary>
/// Provides methods for interacting with the Wardrobe Inventory API to manage wardrobe items.
/// </summary>
public class WardrobeItemService
{
    private static readonly string BaseUrl = "https://localhost:7238/api/wardrobeitems";
    private static readonly string DeleteWardrobeItemRoute = @$"{BaseUrl}/{{id}}";
    private static readonly string GetWardrobeItemRoute = @$"{BaseUrl}/{{id}}";
    private static readonly string GetWardrobeItemsRoute = @$"{BaseUrl}/";
    private static readonly string PostWardrobeItemRoute = @$"{BaseUrl}/";
    private static readonly string PutWardrobeItemRoute = @$"{BaseUrl}/{{id}}";

    public static async Task<BaseResponse> DeleteWardrobeItem(Guid id)
    {
        var response = new BaseResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(DeleteWardrobeItemRoute.Replace("{id}", id.UrlEncoded()));

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Delete);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (!response.IsSuccess)
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }

    public static async Task<WardrobeItemResponse> GetWardrobeItem(Guid id)
    {
        var response = new WardrobeItemResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(GetWardrobeItemRoute.Replace("{id}", id.UrlEncoded()));

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Get);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (response.IsSuccess)
            {
                response.WardrobeItem = JsonSerializer.Deserialize<WardrobeItemDto>(restResponse.Content!, JsonSerializerOptions.Web)!;
            }
            else
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }

    public static async Task<WardrobeItemsResponse> GetWardrobeItems()
    {
        var response = new WardrobeItemsResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(GetWardrobeItemsRoute);

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Get);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (response.IsSuccess)
            {
                response.WardrobeItems = JsonSerializer.Deserialize<IReadOnlyList<WardrobeItemDto>>(restResponse.Content!, JsonSerializerOptions.Web)!;
            }
            else
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }

    public static async Task<WardrobeItemResponse> PostWardrobeItem(WardrobeItemCreateDto request)
    {
        var response = new WardrobeItemResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(PostWardrobeItemRoute);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddBody(JsonSerializer.Serialize(request));

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Post);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (response.IsSuccess)
            {
                response.WardrobeItem = JsonSerializer.Deserialize<WardrobeItemDto>(restResponse.Content!, JsonSerializerOptions.Web)!;
            }
            else
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }

    public static async Task<WardrobeItemResponse> PutWardrobeItem(WardrobeItemDto request)
    {
        var response = new WardrobeItemResponse();

        try
        {
            using var restClient = new RestClient();

            var restRequest = new RestRequest(PutWardrobeItemRoute.Replace("{id}", request.Id.UrlEncoded()));
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddBody(JsonSerializer.Serialize(request));

            var restResponse = await restClient.ExecuteAsync(restRequest, Method.Put);

            response.IsSuccess = restResponse.IsSuccessStatusCode;

            if (response.IsSuccess)
            {
                response.WardrobeItem = JsonSerializer.Deserialize<WardrobeItemDto>(restResponse.Content!, JsonSerializerOptions.Web)!;
            }
            else
            {
                response.Message = restResponse.ErrorMessage ?? "Unknown error has occured";
            }
        }
        catch (Exception exception)
        {
            response.HandleException(exception);
        }

        return response;
    }
}
