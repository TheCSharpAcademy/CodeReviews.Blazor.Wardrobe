using Microsoft.EntityFrameworkCore;
using Buutyful.Wardrobe.Data;
using Buutyful.Wardrobe.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Buutyful.Wardrobe;

public static class WardrobeItemEndpoints
{
    public static void MapWardrobeItemEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WardrobeItem").WithTags(nameof(WardrobeItem));

        group.MapGet("/", async (BuutyfulWardrobeContext db) =>
        {
            return await db.WardrobeItem.ToListAsync();
        })
        .WithName("GetAllWardrobeItems")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<WardrobeItem>, NotFound>> (Guid id, BuutyfulWardrobeContext db) =>
        {
            return await db.WardrobeItem.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is WardrobeItem model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetWardrobeItemById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, WardrobeItem wardrobeItem, BuutyfulWardrobeContext db) =>
        {
            var affected = await db.WardrobeItem
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, wardrobeItem.Id)
                    .SetProperty(m => m.ImgUrl, wardrobeItem.ImgUrl));
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateWardrobeItem")
        .WithOpenApi();

        group.MapPost("/", async (WardrobeItem wardrobeItem, BuutyfulWardrobeContext db) =>
        {
            db.WardrobeItem.Add(wardrobeItem);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/WardrobeItem/{wardrobeItem.Id}",wardrobeItem);
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
