using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<AssetManagementContext>(options => options
            .UseSqlite(configuration.GetConnectionString("AssetManagementDatabase")));
        services.AddScoped<IGenericRepository<Faculty>, GenericRepository<Faculty>>();

        return services;
    }
}