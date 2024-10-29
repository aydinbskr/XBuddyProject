using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{
    internal class AuditLogInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            //var entries = eventData.Context.ChangeTracker.Entries().ToList();
            var auditLogs = eventData.Context.ChangeTracker.Entries()
                .Where(i => i.Entity is not AuditLogEntity)
                .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified || i.State == EntityState.Deleted);


           var auditLogEntities = new List<AuditLogEntity>();
            foreach (var item in auditLogs)
            {
                var log = new AuditLogEntity
                {
                    TableName = item.Metadata.GetTableName(),
                    Operation = item.State.ToString(),
                    CreatedDate = DateTime.Now
                };

                if (item.State == EntityState.Modified)
                {
                    log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(p => p.Name, p => item.OriginalValues[p]));
                    log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(p => p.Name, p => item.CurrentValues[p]));
                }
                else if (item.State == EntityState.Added)
                {
                    log.NewValue = JsonSerializer.Serialize(item.CurrentValues.Properties.ToDictionary(p => p.Name, p => item.CurrentValues[p]));
                }
                else if (item.State == EntityState.Deleted)
                {
                    log.OldValue = JsonSerializer.Serialize(item.OriginalValues.Properties.ToDictionary(p => p.Name, p => item.OriginalValues[p]));
                }

                auditLogEntities.Add(log);
            }
            eventData.Context.Set<AuditLogEntity>().AddRange(auditLogEntities);
            return base.SavingChanges(eventData, result);
        }
    }
}
