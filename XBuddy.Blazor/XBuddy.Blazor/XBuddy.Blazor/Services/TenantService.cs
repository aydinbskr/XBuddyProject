namespace XBuddy.Blazor.Services
{

    public class TenantService : ITenantService
    {
        private string tenantId;
        public string GetTenantId()
        {
            return tenantId;
        }
        public void SetTenantId(string tenantId)
        {
            this.tenantId = tenantId;
        }
    }
}

