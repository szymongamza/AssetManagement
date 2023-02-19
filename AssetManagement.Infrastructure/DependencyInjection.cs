using AssetManagement.Infrastructure.Contexts;
using AssetManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("IdentityDatabase")));

            return services;
        }
    }
}
