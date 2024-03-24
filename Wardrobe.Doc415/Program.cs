using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Wardrobe.Doc415.Data;
using SqliteWasmHelper;


namespace Wardrobe.Doc415
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddSqliteWasmDbContextFactory<WardrobeDb>(opt =>
                opt.UseSqlite($"Data Source=zdb"));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<WardrobeController>();
            await builder.Build().RunAsync();
        }
    }
}
