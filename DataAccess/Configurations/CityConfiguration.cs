using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasMany(c => c.Users).WithOne(u => u.City).HasForeignKey(u => u.CityId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
