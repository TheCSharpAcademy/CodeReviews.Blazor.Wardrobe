using Buutyful.Wardrobe.Components;
using Microsoft.EntityFrameworkCore;
using Buutyful.Wardrobe.Data;
using Buutyful.Wardrobe.EndPoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BuutyfulWardrobeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BuutyfulWardrobeContext") ?? 
    throw new InvalidOperationException("Connection string 'BuutyfulWardrobeContext' not found.")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Buutyful.Wardrobe.Client._Imports).Assembly);

app.MapWardrobeItemEndpoints();

app.Run();
