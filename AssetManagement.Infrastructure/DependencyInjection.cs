using AssetManagement.Application.Services;
using AssetManagement.Domain.Entities.Identity;
using AssetManagement.Infrastructure.Data;
using AssetManagement.Infrastructure.Identity;
using AssetManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AssetManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddDbContext<AssetManagementContext>(options => options
                .UseSqlite(configuration.GetConnectionString("AssetManagementDatabase")));
            services.AddIdentityCore<AppUser>()
                .AddEntityFrameworkStores<AssetManagementContext>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
