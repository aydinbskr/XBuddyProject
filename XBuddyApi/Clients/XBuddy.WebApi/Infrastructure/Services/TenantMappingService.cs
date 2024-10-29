using XBuddy.Infra.SqlServer.Context;

namespace XBuddy.WebApi.Infrastructure.Services
{
    public class TenantMappingService : ITenantMappingService
    {
        private TenantMappingContext dbContext;
        private readonly IServiceProvider serviceProvider;
        private Dictionary<string, Guid> map;

        public TenantMappingService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            LoadMap();
        }

        public Guid? GetUseyByTenantId(string tenantid)
        {

            return map.TryGetValue(tenantid, out var userId) ? userId : null;
        }

        private void LoadMap()
        {
            using var scope = serviceProvider.CreateScope();
            dbContext = scope.ServiceProvider.GetService<TenantMappingContext>();
            map = dbContext.TenantMappings.ToDictionary(i => i.TenantId, i => i.UserId);
        }
    }
}
