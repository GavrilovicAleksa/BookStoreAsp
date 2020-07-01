using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(25);

            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);

            builder.Property(x => x.CityId).IsRequired();

            builder.HasMany(p => p.BookPublishers).WithOne(bp => bp.Publisher).HasForeignKey(bp => bp.PublisherId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
