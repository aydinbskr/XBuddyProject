namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantCookieResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            //https://baseUrl/{tenantId}/.....
            return httpContextAccessor.HttpContext
                .Request?
                .Cookies[IMultiTenantResolver.TenantIdKey];
        }
    }
}
