using Microsoft.EntityFrameworkCore;
using Buutyful.Wardrobe.Data;
using Buutyful.Wardrobe.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Buutyful.Wardrobe.Shared.Contracts;
namespace Buutyful.Wardrobe.EndPoints;

public static class WardrobeItemEndpoints
{
    public static void MapWardrobeItemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WardrobeItem").WithTags(nameof(WardrobeItem));

        group.MapGet("/", async (BuutyfulWardrobeContext db) =>
        {
            var list = await db.WardrobeItem.ToListAsync();
            return list.MapToResponseList();
        })
        .WithName("GetAllWardrobeItems")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<WardrobeItemResponse>, NotFound>> (Guid id, BuutyfulWardrobeContext db) =>
        {
            return await db.WardrobeItem.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is WardrobeItem model
                    ? TypedResults.Ok(model.MapToResponse())
                    : TypedResults.NotFound();
        })
        .WithName("GetWardrobeItemById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, UpdateWardrobeItem wardrobeItem, BuutyfulWardrobeContext db) =>
        {
            var affected = await db.WardrobeItem
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, id)
                    .SetProperty(m => m.WardrobeId, wardrobeItem.WardrobeId)
                    .SetProperty(m => m.ImgUrl, wardrobeItem.ImgUrl)
                    .SetProperty(m => m.ClothingType, wardrobeItem.ClothingType)
                    .SetProperty(m => m.Description, wardrobeItem.Description));
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateWardrobeItem")
        .WithOpenApi();

        group.MapPost("/", async (CreateWardrobeItem wardrobeItem, BuutyfulWardrobeContext db) =>
        {
            var item = wardrobeItem.CreateFromRequest();
            db.WardrobeItem.Add(item);
            await db.SaveChangesAsync();
            var response = item.MapToResponse();
            return TypedResults.Created($"/api/WardrobeItem/{response.Id}", response);
        })
        .WithName("CreateWardrobeItem")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, BuutyfulWardrobeContext db) =>
        {
            var affected = await db.WardrobeItem
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteWardrobeItem")
        .WithOpenApi();
    }
}
