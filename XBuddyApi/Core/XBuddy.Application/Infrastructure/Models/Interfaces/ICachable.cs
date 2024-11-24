using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Infrastructure.Models.MultiTenant;

namespace XBuddy.Application.Infrastructure.Models.Interfaces
{
    public interface ICacheable
    {
        public string CacheKey { get; }

        public bool? IgnoreCacheRead { get; set; }
        public bool? IgnoreCacheWrite { get; set; }
    }
    public interface ITenantCacheable:IMultiTenant, ICacheable
    {

    }
}
