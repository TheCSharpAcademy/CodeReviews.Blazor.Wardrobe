using Bogus;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Entities;
using WardrobeInventory.Enums;

namespace WardrobeInventory.Api.Services;

/// <summary>
/// Provides methods to seed the database with initial data.
/// This service uses <see href="https://github.com/bchavez/Bogus">Bogus</see> to add a hundred random fake wardrobe items to a fresh database.
/// </summary>
public class SeederService(WardrobeInventoryDbContext context) : ISeederService
{
    private static readonly string[] _wardrobeItems =
    [
        "Shirt",
        "Polo Shirt",
        "T-Shirt",
        "Sweater",
        "Jacket",
        "Coat",
        "Jeans",
        "Trousers",
        "Shorts",
        "Dress",
        "Skirt",
        "Blouse",
        "Cardigan",
        "Hoody",
        "Suit",
        "Blazer",
        "Pajamas",
        "Underwear",
        "Socks",
        "Scarf",
        "Hat",
        "Gloves",
        "Belt",
        "Tie",
        "Belt"
    ];

    public void SeedDatabase()
    {
        if (context.WardrobeItems.Any())
        {
            return;
        }

        Randomizer.Seed = new Random(19890309);

        SeedWardrobeItems();
    }

    private void SeedWardrobeItems()
    {
        var fakeData = new Faker<WardrobeItem>()
            .RuleFor(m => m.Id, f => f.Random.Guid())
            .RuleFor(m => m.Name, f => $"{f.Commerce.ProductAdjective()} {f.PickRandom(_wardrobeItems)}")
            .RuleFor(m => m.Colour, f => f.PickRandom<WardrobeItemColours>())
            .RuleFor(m => m.Material, f => f.PickRandom<WardrobeItemMaterials>())
            .RuleFor(m => m.Size, f => f.PickRandom<WardrobeItemSizes>());

        foreach (var fake in fakeData.Generate(100))
        {
            context.WardrobeItems.Add(fake);
        }

        context.SaveChanges();
    }
}
