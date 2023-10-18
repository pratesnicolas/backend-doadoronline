using DoadorOnline.BrasilApiService;
using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoadorOnline.Application;
public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddIdentityCore<User>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

        services.RegisterInfraServices();

        return services;
    }
}

