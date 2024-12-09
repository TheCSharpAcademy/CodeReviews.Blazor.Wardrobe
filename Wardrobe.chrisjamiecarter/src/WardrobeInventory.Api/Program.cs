using WardrobeInventory.Api.Installers;

namespace WardrobeInventory.Api;

/// <summary>
/// The entry point for the Wardrobe Inventory API application.
/// Configures and runs the application, setting up services and middleware.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApi();
        builder.Services.AddInfrastructure();

        var app = builder.Build();
        app.AddMiddleware();
        app.SetUpDatabase();
        app.Run();
    }
}
