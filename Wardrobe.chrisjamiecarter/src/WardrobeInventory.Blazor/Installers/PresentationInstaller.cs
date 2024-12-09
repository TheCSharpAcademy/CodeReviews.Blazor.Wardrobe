using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WardrobeInventory.Blazor.Services;

namespace WardrobeInventory.Blazor.Installers;

/// <summary>
/// Provides extension methods for configuring and setting up the Presentation services and middleware in the Wardrobe Inventory application.
/// </summary>
public static class PresentationInstaller
{
    public static WebAssemblyHostBuilder AddPresentation(this WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddScoped<ImageFileService>();
        builder.Services.AddScoped<ToastService>();
        builder.Services.AddScoped<WardrobeItemService>();

        return builder;
    }
}
