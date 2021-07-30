using FootMark.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FootMark.Web.Configure
{
    public static class AddDatabaseConfig
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<FootMarkDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("FootMarkConnection")));

        }
    }
}
