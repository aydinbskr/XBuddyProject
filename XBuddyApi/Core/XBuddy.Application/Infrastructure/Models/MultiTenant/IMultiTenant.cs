using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Application.Infrastructure.Models.MultiTenant
{
    public interface IMultiTenant
    {
        string TenantId { get; set; }
    }
}
