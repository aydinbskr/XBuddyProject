
namespace XBuddy.WebApi.Infrastructure.Services
{
    public interface ITenantMappingService
    {
        Guid? GetUseyByTenantId(string tenantid);
    }
}