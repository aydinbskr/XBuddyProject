namespace XBuddy.Blazor.Services
{
    public interface ITenantService
    {
        string GetTenantId();
        void SetTenantId(string tenantId);
    }
}