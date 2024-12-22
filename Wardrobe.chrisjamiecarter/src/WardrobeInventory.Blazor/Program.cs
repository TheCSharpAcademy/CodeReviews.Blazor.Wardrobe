using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WardrobeInventory.Blazor.Installers;

namespace WardrobeInventory.Blazor;

/// <summary>
/// The entry point for the Wardrobe Inventory Blazor application.
/// Configures and runs the application, setting up services and middleware.
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.AddPresentation();

        var app = builder.Build();
        await app.RunAsync();
    }
}
