using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Infra.Cosmos.Models
{

    public record BaseCosmosModel<T>
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Newtonsoft.Json.JsonProperty("tenantid")]
        public string TenantId { get; set; }

        public T Value { get; set; }
    }
}
