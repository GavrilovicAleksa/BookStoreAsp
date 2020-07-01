using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(x => x.UserId).IsRequired();

            builder.HasMany(c => c.CartItems).WithOne(ci => ci.Cart).HasForeignKey(ca => ca.Cart).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
