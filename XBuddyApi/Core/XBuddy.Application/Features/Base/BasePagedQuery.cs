using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Infrastructure.Models.Interfaces;
using XBuddyModels.Paging;

namespace XBuddy.Application.Features.Base
{
    public class BasePagedQuery<T> : BasePagedQuery, IRequest<T>
    {
        public BasePagedQuery(int PageNumber, int PageSize) : base(PageNumber, PageSize)
        {
        }
        public BasePagedQuery():this(1,10)
        {
                
        }
    }
    public class BasePagedQuery(int pageNumber, int pageSize)
    {
        public int PageNumber { get; set; } = pageNumber;
        public int PageSize { get; set; } = pageSize;
    }

    public class CacheablePagedQuery<T>: CacheablePagedQuery,IRequest<PagedResponse<T>> where T:class
    {

    }

    public class CacheablePagedQuery : BasePagedQuery, ITenantCacheable
    {
        public CacheablePagedQuery(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }
        public CacheablePagedQuery() : this(1, 10)
        {

        }
        public string TenantId { get ; set ; }

        public virtual string CacheKey { get; }

        public bool? IgnoreCacheRead { get; set; }
        public bool? IgnoreCacheWrite { get ; set; }
    }
}
