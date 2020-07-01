using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.Property(x => x.Quantity).IsRequired().HasMaxLength(30);

            builder.Property(x => x.BookId).IsRequired();

            builder.Property(x => x.CartId).IsRequired();

        }
    }
}
