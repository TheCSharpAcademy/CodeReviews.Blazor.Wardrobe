using Kmakai.WardrobeInventory.Client.Pages;
using Kmakai.WardrobeInventory.Components;
using Microsoft.EntityFrameworkCore;
using Kmakai.WardrobeInventory.Context;
using Kmakai.WardrobeInventory.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<WardrobeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WardrobeContext")));

builder.Services.AddScoped<WardrobeService>();

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeederData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Kmakai.WardrobeInventory.Client._Imports).Assembly);

app.MapControllers();

app.Run();
