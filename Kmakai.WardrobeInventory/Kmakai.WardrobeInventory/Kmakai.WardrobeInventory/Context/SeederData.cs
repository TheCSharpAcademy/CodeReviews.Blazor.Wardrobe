using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Kmakai.WardrobeInventory.Context;

public static class SeederData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new WardrobeContext(serviceProvider.GetRequiredService<DbContextOptions<WardrobeContext>>());

        context.Database.EnsureCreated();

        SeedImages(context);

        SeedWardrobeItems(context);

        SeedWardrobes(context);

    }

    public static void SeedImages(WardrobeContext context)
    {
        context.wardrobeImages.AddRange(
            new WardrobeImage
            {
                ImageUrl = "seedImages/shirt1.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/shirt2.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/shirt3.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/pants1.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/pants2.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/pants3.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/shoes1.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/shoes2.jpg"
            },
            new WardrobeImage
            {
                ImageUrl = "seedImages/shoes3.jpg"
            }
            );

        context.SaveChanges();


    }

    private static void SeedWardrobeItems(WardrobeContext context)
    {
        context.WardrobeItems.AddRange(
            new WardrobeItem
            {
                Name = "T-shirt",
                Color = "White",
                Description = "A comfortable t-shirt",
                ImageId = 1,
                ItemType = ItemType.Top
            },
            new WardrobeItem
            {
                Name = "Button down polo",
                Color = "Green",
                Description = "A proffesional green button down polo",
                ImageId = 2,
                ItemType = ItemType.Top
            },
            new WardrobeItem
            {
                Name = "Polo shirt",
                Color = "Blue",
                Description = "A nice comfortable polo shirt for work",
                ImageId = 3,
                ItemType = ItemType.Top
            },
            new WardrobeItem
            {
                Name = "Work Jeans",
                Color = "Black",
                Description = "A pair of black work jeans",
                ImageId = 4,
                ItemType = ItemType.Bottom
            },
            new WardrobeItem
            {
                Name = "Casual Jeans",
                Color = "Brown",
                Description = "A pair of blue casual jeans",
                ImageId = 5,
                ItemType = ItemType.Bottom
            },
            new WardrobeItem
            {
                Name = "Jeans",
                Color = "Green",
                Description = "A pair of comfortable green jeans",
                ImageId = 6,
                ItemType = ItemType.Bottom
            },
            new WardrobeItem
            {
                Name = "Casual shoes",
                Color = "Black",
                Description = "A pair of black casual shoes",
                ImageId = 7,
                ItemType = ItemType.Footwear
            },
            new WardrobeItem
            {
                Name = "Running shoes",
                Color = "Green",
                Description = "A pair of green running shoes",
                ImageId = 8,
                ItemType = ItemType.Footwear
            },
            new WardrobeItem
            {
                Name = "Work shoes",
                Color = "Green",
                Description = "A pair of green work shoes",
                ImageId = 9,
                ItemType = ItemType.Footwear
            }
            );

        context.SaveChanges();

    }

    private static void SeedWardrobes(WardrobeContext context)
    {
        context.wardrobes.AddRange(
            new Wardrobe
            {
                Name = "Work Wardrobe",
                TopId = 1,
                BottomId = 4,
                FootwearId = 9
            },
            new Wardrobe
            {
                Name = "Casual Wardrobe",
                TopId = 2,
                BottomId = 5,
                FootwearId = 8
            },
            new Wardrobe
            {
                Name = "Running Wardrobe",
                TopId = 3,
                BottomId = 6,
                FootwearId = 7
            }
            );
        context.SaveChanges();
    }
}
