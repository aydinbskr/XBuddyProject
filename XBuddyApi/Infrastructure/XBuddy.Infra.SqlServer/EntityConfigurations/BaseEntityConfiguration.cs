using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{

    public abstract class BaseEntityConfiguration<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity>
        where TBaseEntity : BaseEntity<Guid>
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");
            builder.Property(x => x. CreatedDate). IsRequired();
            builder.Property(x => x. ModifiedDate). IsRequired(false);
        }
    }
}
