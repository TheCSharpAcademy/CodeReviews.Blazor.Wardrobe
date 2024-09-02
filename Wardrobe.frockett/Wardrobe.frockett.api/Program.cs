using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;
using Wardrobe.frockett.api.Data;
using Wardrobe.frockett.api.Models;
using Wardrobe.frockett.api.Repository;
using Wardrobe.frockett.Repository;
using System.Text.Json;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Wardrobe.frockett.api.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAntiforgery();

builder.Services.AddDbContext<ClosetContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClosetRepository, ClosetRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseCors("AllowAll");

app.MapGet("/api/closet", async (IClosetRepository repo) =>
    await repo.GetAllItemsAsync());

// GET item by id
app.MapGet("/api/closet/{id}", async (int id, IClosetRepository repo) =>
{
    var item = await repo.GetItemByIdAsync(id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

// POST new item
app.MapPost("/api/closet", async (
    [FromForm] string item,
    IFormFile? image,
    IClosetRepository repo) =>
{
    var clothingItem = JsonSerializer.Deserialize<ItemDto>(item, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    ClothingItem newItem = new();
    if (image != null)
    {
        newItem = await repo.AddItemAsync(clothingItem, image);
    }
    else
    {
        newItem = await repo.AddItemAsync(clothingItem, null);
    }

    return Results.Created($"/api/closet/{newItem.Id}", newItem);
}).DisableAntiforgery();

// PUT update item
app.MapPut("/api/closet/{id}", async (int id, IFormFile? image, [FromForm] string item, IClosetRepository repo) =>
{
    var clothingItem = JsonSerializer.Deserialize<ItemDto>(item, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    });

    if (id != clothingItem.Id)
        return Results.BadRequest();

    ClothingItem updatedItem = image != null ? await repo.UpdateItemAsync(clothingItem, image) : await repo.UpdateItemAsync(clothingItem, null);

    return updatedItem is null ? Results.NotFound() : Results.NoContent();
}).DisableAntiforgery();

// DELETE item
app.MapDelete("/api/closet/{id}", async (int id, IClosetRepository repo) =>
{
    var result = await repo.DeleteItemAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});

app.Run();


