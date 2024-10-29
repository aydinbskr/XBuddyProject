using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Domain.Entities;
using XBuddy.Infra.SqlServer.EntityConfigurations;

namespace XBuddy.Infra.SqlServer.Context
{
    public class TenantMappingContext(DbContextOptions<TenantMappingContext> options):DbContext(options)
    {
        public DbSet<TenantMappingEntity> TenantMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("xb");
            modelBuilder.ApplyConfiguration(new TenantMappingEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
