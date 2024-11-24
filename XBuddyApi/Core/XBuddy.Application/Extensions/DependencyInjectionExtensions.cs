using Mapster;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Infrastructure.PipelineBehaviours;

namespace XBuddy.Application.Extensions
{

    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediator(opt =>
            {
                opt.ServiceLifetime = ServiceLifetime.Scoped;
            });
            services.AddMapster();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TenantCachePipelineBehaviour<,>));
            return services;
        }
    }
}
