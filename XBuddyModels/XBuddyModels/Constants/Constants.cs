using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddyModels.Constants
{
    public class Constants
    {
        public class CacheKeys
        {
            public const string UserFeed = "user_feed";
        }
    }

    public class MultiTenantConstants
    {
        public const string TenantId = "tenantId";
    }

    public class CosmosConstants
    {
        public const string CacheDbName = "cache_db";
        public const string FeedCacheContainerName = "feed_cache";
        public const string UserSettings = "user_settings";
    }
    public class ServiceBusConstants
    {
        public const string PostViewQueueName = "post-view";
    }
    public class RouteConstants
    {
        public const string PostViewApi = "PostViewed";
    }
}
