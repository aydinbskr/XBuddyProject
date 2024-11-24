using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace XBuddy.Application.Services
{

    public interface ITenantCacheService
    {
        Task SetCache<T>(string tenantId, string key, T value);
        Task<T> GetCache<T>(string tenantId, string key);
    }
    
    
}
