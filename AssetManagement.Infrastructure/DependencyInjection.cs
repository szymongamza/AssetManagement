using AssetManagement.Application.Interfaces;
using AssetManagement.Application.Interfaces.Repositories;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;
using AssetManagement.Infrastructure.Repositories;
using AssetManagement.Infrastructure.Services;
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
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<AssetManagementContext>(options => options
            .UseSqlite(configuration.GetConnectionString("AssetManagementDatabase")));
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}