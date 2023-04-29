using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        //Security Services
        services.AddScoped<ITokenService, JwtHelper>();
        services.AddScoped<HashingHelper>();

        return services;

    }
}