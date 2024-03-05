using Buutyful.Wardrobe.Client.Clients;

namespace Buutyful.Wardrobe;

public static class DependencyInjection
{
    public static IServiceCollection AddServer(this IServiceCollection services)
    {

        services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
    public static IServiceCollection AddClient(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddHttpClient<IHttpWardRobeClient, HttpWardRobeClient>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["BaseUrl:ApiUrl"] ??
                throw new ArgumentNullException("missing base url in configuration"));
        });
        return services;
    }
}
