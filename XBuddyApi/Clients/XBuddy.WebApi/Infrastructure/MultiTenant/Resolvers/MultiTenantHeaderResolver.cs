namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantHeaderResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            //https://baseUrl/{tenantId}/.....
            return httpContextAccessor.HttpContext
                .Request?
                .Headers[IMultiTenantResolver.TenantIdKey];
        }
    }
}
