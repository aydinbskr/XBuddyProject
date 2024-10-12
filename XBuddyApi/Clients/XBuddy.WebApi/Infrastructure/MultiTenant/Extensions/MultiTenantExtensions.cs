using Microsoft.Extensions.DependencyInjection.Extensions;
using XBuddy.WebApi.Infrastructure.Middleware;
using XBuddy.WebApi.Infrastructure.MultiTenant.Options;
using XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers;
using XBuddy.WebApi.Infrastructure.MultiTenant.Services;

namespace XBuddy.WebApi.Infrastructure.MultiTenant.Extensions
{

    public static class MultiTenantExtensions
    {

        public static IServiceCollection AddMultiTenancy(this IServiceCollection services)
        {
            AddMultiTenancy(services, opt =>
            {
                opt.UseRouteResolver()
                    .UseQueryStringResolver()
                    .UseHeaderResolver()
                    .UseCookieResolver();
            });

            return services;
        }
        public static IServiceCollection AddMultiTenancy(this IServiceCollection services, Action<MultiTenancyOptions> optAction)
        {
            services.AddHttpContextAccessor();

            services.AddSingleton<MultiTenantMiddleware>();
            services.AddScoped<IMultiTenantService, MultiTenantService>();

            var opt = new MultiTenancyOptions();
            optAction(opt);
            if(opt.InternalUseRouteResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantUrlRouteResolver>());
            }
            if (opt.InternalUseQueryStringResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantQueryStringResolver>());
            }
            if (opt.InternalUseHeaderResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantHeaderResolver>());
            }
            if (opt.InternalUseCookieResolver)
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<IMultiTenantResolver, MultiTenantCookieResolver>());
            }
            if (!opt.AtleastOneActive)
                throw new Exception("No MultiTenantResolver found!");
            return services;
        }
        public static IApplicationBuilder UseMultiTenancy(this IApplicationBuilder app)
        {
            app.UseMiddleware<MultiTenantMiddleware>();
            return app;
        }

    }
}
