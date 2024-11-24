using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Infrastructure.Models.Interfaces;
using XBuddy.Application.Services;

namespace XBuddy.Application.Infrastructure.PipelineBehaviours
{
    public class TenantCachePipelineBehaviour<Treq, Tres>(ITenantCacheService tenantCacheService) : IPipelineBehavior<Treq, Tres>
        where Treq :IRequest<Tres>,ITenantCacheable
        where Tres:class
    {
        public async ValueTask<Tres> Handle(Treq message, CancellationToken cancellationToken, MessageHandlerDelegate<Treq, Tres> next)
        {
            if(message.IgnoreCacheRead == false)
            {
                Tres cachedValue = await tenantCacheService.GetCache<Tres>(message.TenantId, message.CacheKey);

                if (cachedValue is not null)
                {
                    return cachedValue;
                }
            }
            

            var response = await next(message, cancellationToken);
            if(message.IgnoreCacheWrite is false && response is not null)
            {
                await tenantCacheService.SetCache(message.TenantId, message.CacheKey, response);
            }

            return response;
        }
    }
}
