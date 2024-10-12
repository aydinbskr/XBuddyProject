using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace XBuddyModels.Extensions
{

    public static class StringExtensions
    {
        public static string ToPagedQueryString(this string pageUrl, int pageNumber, int pageSize)
        {
            return ToQuery(pageUrl, "pageNumber", pageNumber.ToString())
                   .ToQuery("pageSize", pageSize.ToString());
        }

        public static string ToQuery(this string pageUrl, string key, string value)
        {
            var uriBuilder = new UriBuilder(pageUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query); query[key] = value;
            uriBuilder.Query = query.ToString();
            return string.Concat(uriBuilder.Host, uriBuilder.Query);
        }
    }
}
