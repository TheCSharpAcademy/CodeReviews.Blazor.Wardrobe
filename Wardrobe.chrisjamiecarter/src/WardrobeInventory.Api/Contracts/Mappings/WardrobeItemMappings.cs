using WardrobeInventory.Api.Contracts.Requests;
using WardrobeInventory.Api.Contracts.Responses;
using WardrobeInventory.Entities;

namespace WardrobeInventory.Api.Contracts.Mappings;

/// <summary>
/// Provides extension methods for mapping between domain models and request/response contracts 
/// in the Wardrobe Inventory application.
/// </summary>
public static class WardrobeItemMappings
{
    public static WardrobeItem ApplyUpdate(this WardrobeItem entity, WardrobeItemUpdateRequest request)
    {
        entity.Name = request.Name;
        entity.Colour = request.Colour;
        entity.Material = request.Material;
        entity.Size = request.Size;

        if (!string.IsNullOrWhiteSpace(request.ImagePath))
        {
            entity.ImagePath = request.ImagePath;
        }

        return entity;
    }

    public static WardrobeItem ToDomain(this WardrobeItemCreateRequest request)
    {
        var entity = new WardrobeItem
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Colour = request.Colour,
            Material = request.Material,
            Size = request.Size,
        };

        if (!string.IsNullOrWhiteSpace(request.ImagePath))
        {
            entity.ImagePath = request.ImagePath;
        }

        return entity;
    }

    public static WardrobeItemResponse ToResponse(this WardrobeItem entity)
    {
        return new WardrobeItemResponse(entity.Id, entity.Name, entity.ImagePath, entity.Colour, entity.Material, entity.Size);
    }

    public static IReadOnlyList<WardrobeItemResponse> ToReponse(this IReadOnlyList<WardrobeItem> entities)
    {
        return entities.Select(x => x.ToResponse()).ToList();
    }
}
