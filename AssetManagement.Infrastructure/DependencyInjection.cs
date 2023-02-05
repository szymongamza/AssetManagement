using AssetManagement.Application.Common.Interfaces.Authentication;
using AssetManagement.Application.Common.Interfaces.Persistence;
using AssetManagement.Application.Common.Interfaces.Services;
using AssetManagement.Infrastructure.Authentication;
using AssetManagement.Infrastructure.Persistence;
using AssetManagement.Infrastructure.Services;
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
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
