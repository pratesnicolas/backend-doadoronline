using Microsoft.Extensions.DependencyInjection;

namespace DoadorOnline.Infrastructure;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterInfraServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}


