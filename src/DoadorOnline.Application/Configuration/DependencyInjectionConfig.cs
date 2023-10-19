using DoadorOnline.BrasilApiService;
using DoadorOnline.Domain;
using DoadorOnline.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoadorOnline.Application;
public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services,
                                                      IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddDefaultIdentity<Donator>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddTokenProvider<DataProtectorTokenProvider<Donator>>(TokenOptions.DefaultProvider);

        services.Configure<DataProtectionTokenProviderOptions>(options =>
               options.TokenLifespan = TimeSpan.FromDays(30));

        services.RegisterInfraServices();
        services.RegisterBrasilApiServices(configuration);

        return services;
    }
}

