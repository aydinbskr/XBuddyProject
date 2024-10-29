using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Helpers;

namespace XBuddy.Infra.SqlServer.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddSqlServices(this IServiceCollection services,
            string connectionString, GetTenantIdDelegate tenantIdDelegate)
        {
            services.AddDbContext<TenantMappingContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<TenantMappingContext>>();
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<XBuddyDbContext>((sp, options) =>
            {
                var logger = sp.GetRequiredService<ILogger<XBuddyDbContext>>();
                options.UseSqlServer(connectionString);
#if DEBUG
                options.EnableSensitiveDataLogging(true);
#endif
            });

            services.AddSingleton(tenantIdDelegate);

            return services;
        }
    }
}
