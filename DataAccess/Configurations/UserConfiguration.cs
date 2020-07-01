using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<Domain.User> builder)
        {
            builder.HasAlternateKey(x => x.Username);

            builder.Property(x => x.Username).HasMaxLength(30);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);

            builder.HasMany(u => u.Carts).WithOne(o => o.User).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
