using System.Reflection;
using Application.BusinessRules;
using Application.Services;
using Application.Services.IServices;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<IAuthService, AuthManager>();
        return services;
    }
}