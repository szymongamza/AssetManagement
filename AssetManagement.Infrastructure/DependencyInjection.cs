using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Common.Interfaces.Repositories;
using AssetManagement.Application.Common.Interfaces.Services;
using AssetManagement.Infrastructure.Authentication;
using AssetManagement.Infrastructure.Contexts;
using AssetManagement.Infrastructure.Repositories;
using AssetManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddDbContext<AssetManagementContext>(options => options
                .UseSqlite(configuration.GetConnectionString("ApiDatabase")));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient(typeof(IRepositoryAsync<,>),typeof(RepositoryAsync<,>));

            return services;
        }
    }
}
