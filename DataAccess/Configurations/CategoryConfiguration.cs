using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            //builder.HasMany(c => c.Books).WithOne(b => b.Category).HasForeignKey(b => b.CategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
