using AssetManagement.Application.Helpers;
using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        return services;
    }
}