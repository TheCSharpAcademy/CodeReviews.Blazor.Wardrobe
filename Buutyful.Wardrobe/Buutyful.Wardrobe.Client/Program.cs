using Buutyful.Wardrobe.Client.Clients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IHttpWardRobeClient, HttpWardRobeClient>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddScoped<IHttpWardRobeClient, HttpWardRobeClient>();


await builder.Build().RunAsync();
