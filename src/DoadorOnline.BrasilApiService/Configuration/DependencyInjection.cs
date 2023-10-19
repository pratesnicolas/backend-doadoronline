using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoadorOnline.BrasilApiService;

public static class DependencyInjection
{
    public static IServiceCollection RegisterBrasilApiServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.Configure<BrasilApiSettings>(configuration.GetSection(nameof(BrasilApiSettings)));
        services.AddHttpClient<IBrasilApiService, BrasilApiService>();
        return services;
    }
}
