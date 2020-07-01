using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);

            builder.HasMany(a => a.BookAuthors).WithOne(bk => bk.Author).HasForeignKey(bk => bk.AuthorId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
