﻿namespace XBuddy.WebApi.Infrastructure.MultiTenant.Resolvers
{
    public class MultiTenantUrlRouteResolver(IHttpContextAccessor httpContextAccessor) : IMultiTenantResolver
    {
        public string Resolve()
        {
            //https://baseUrl/{tenantId}/.....
            return httpContextAccessor.HttpContext
                .Request?
                .RouteValues[IMultiTenantResolver.TenantIdKey]?
                .ToString();
        }
    }
}