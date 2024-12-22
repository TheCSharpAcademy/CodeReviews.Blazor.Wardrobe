using Microsoft.AspNetCore.Mvc;
using WardrobeInventory.Api.Contracts.Mappings;
using WardrobeInventory.Api.Contracts.Requests;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Controllers;

/// <summary>
/// Provides API endpoints for managing wardrobe items in the Wardrobe Inventory application.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WardrobeItemsController(IWardrobeItemRepository repository) : ControllerBase
{
    [HttpDelete("{id}", Name = nameof(DeleteWardrobeItemAsync))]
    public async Task<IResult> DeleteWardrobeItemAsync([FromRoute] Guid id)
    {
        var entity = await repository.ReturnAsync(id);
        if (entity is null)
        {
            return TypedResults.NotFound();
        }

        var result = await repository.DeleteAsync(entity);

        return result
            ? TypedResults.NoContent()
            : TypedResults.BadRequest(new { error = "Unable to delete wardrobe item." });
    }

    [HttpGet("{id}", Name = nameof(GetWardrobeItemAsync))]
    public async Task<IResult> GetWardrobeItemAsync([FromRoute] Guid id)
    {
        var entity = await repository.ReturnAsync(id);

        return entity is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(entity.ToResponse());
    }

    [HttpGet(Name = nameof(GetWardrobeItemsAsync))]
    public async Task<IResult> GetWardrobeItemsAsync()
    {
        var entities = await repository.ReturnAsync();

        return TypedResults.Ok(entities.ToReponse());
    }

    [HttpPost(Name = nameof(PostWardrobeItemAsync))]
    public async Task<IResult> PostWardrobeItemAsync([FromBody] WardrobeItemCreateRequest request)
    {
        var entity = request.ToDomain();

        var result = await repository.CreateAsync(entity);

        return result
            ? TypedResults.CreatedAtRoute(entity.ToResponse(), nameof(GetWardrobeItemAsync), new { id = entity.Id })
            : TypedResults.BadRequest(new { error = "Unable to post wardrobe item." });
    }

    [HttpPut("{id}", Name = nameof(PutWardrobeItemAsync))]
    public async Task<IResult> PutWardrobeItemAsync([FromRoute] Guid id, [FromBody] WardrobeItemUpdateRequest request)
    {
        var entity = await repository.ReturnAsync(id);
        if (entity is null)
        {
            return TypedResults.NotFound();
        }

        var updatedEntity = entity.ApplyUpdate(request);

        var result = await repository.UpdateAsync(updatedEntity);

        return result
            ? TypedResults.Ok(entity.ToResponse())
            : TypedResults.BadRequest(new { error = "Unable to put wardrobe item." });
    }
}
