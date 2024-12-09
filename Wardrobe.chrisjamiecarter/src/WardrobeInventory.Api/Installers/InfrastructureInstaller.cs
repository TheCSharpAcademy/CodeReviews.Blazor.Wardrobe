using Microsoft.EntityFrameworkCore;
using WardrobeInventory.Api.Contexts;
using WardrobeInventory.Api.Repositories;
using WardrobeInventory.Api.Services;
using WardrobeInventory.Repositories;

namespace WardrobeInventory.Api.Installers;

/// <summary>
/// Provides extension methods for configuring the infrastructure services in the Wardrobe Inventory application.
/// </summary>
public static class InfrastructureInstaller
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var fileName = $"{nameof(WardrobeInventory)}.db";
        var filePath = Path.Combine(directoryPath, fileName);

        var connectionString = $"Data Source={filePath}";

        services.AddDbContext<WardrobeInventoryDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IWardrobeItemRepository, WardrobeItemRepository>();
        
        services.AddScoped<ISeederService, SeederService>();

        return services;
    }

    public static IServiceProvider SeedDatabase(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<WardrobeInventoryDbContext>();

        context.Database.EnsureCreated();

        var seeder = serviceProvider.GetRequiredService<ISeederService>();
        seeder.SeedDatabase();

        return serviceProvider;
    }
}
