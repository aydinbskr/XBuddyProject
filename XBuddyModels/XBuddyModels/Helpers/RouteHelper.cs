using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddyModels.Constants;

namespace XBuddyModels.Helpers
{

    public static class RouteHelper
    {
        public static string AdjustTenantRoute(this string route)
        {
            var totalLength = MultiTenantConstants.TenantId.Length + route.Length + 2;
            var sbRoute = new StringBuilder(totalLength);
            sbRoute.Append('/');
            sbRoute.AppendFormat("{{{0}}}", MultiTenantConstants.TenantId);
            if (!route.StartsWith('/'))
            {
                sbRoute.Append('/');
            }

            sbRoute.Append(route);
            return sbRoute.ToString();
        }

    }
}
