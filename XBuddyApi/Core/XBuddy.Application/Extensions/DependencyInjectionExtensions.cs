using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return services;
        }
    }
}
