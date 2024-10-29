﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using XBuddy.Domain.Entities;

namespace XBuddy.Infra.SqlServer.EntityConfigurations
{

    public sealed class TweetEntityConfiguration : BaseEntityConfiguration<TweetEntity>
    {
        public new void Configure(EntityTypeBuilder<TweetEntity> builder)
        {
            builder.Property(x => x.Content).IsRequired().HasMaxLength(280);

            builder.Property(x => x.UserId).IsRequired();
            builder.HasOne(x => x.User)
            .WithMany(x => x.Tweets)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
