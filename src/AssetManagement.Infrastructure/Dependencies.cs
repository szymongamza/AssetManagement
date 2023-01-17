using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssetManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(c=>
                c.UseInMemoryDatabase("InMemory"));
        }
    }
}
