namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantQueryStringResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            //https://baseUrl/{tenantId}/.....
            return httpContextAccessor.HttpContext
                .Request?
                .Query[IMultiTenantResolver.TenantIdKey];
        }
    }
}
