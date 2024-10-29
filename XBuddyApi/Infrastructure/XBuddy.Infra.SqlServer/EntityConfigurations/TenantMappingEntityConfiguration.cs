using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{

    public sealed class TenantMappingEntityConfiguration : BaseEntityConfiguration<TenantMappingEntity>
    {
        public new void Configure(EntityTypeBuilder<TenantMappingEntity> builder)
        {
            builder.Property(x => x.TenantId).IsRequired(); 
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.User)
            .WithOne(x => x.TenantMapping)
            .HasForeignKey<TenantMappingEntity>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
        
    }
}
