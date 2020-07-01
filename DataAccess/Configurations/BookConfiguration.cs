using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.Property(x => x.Title).IsRequired().HasMaxLength(30);

            //builder.HasMany(b => b.Images).WithOne(i => i.Book).HasForeignKey(i => i.BookId).OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(b => b.BookAuthors).WithOne(bk => bk.Book).HasForeignKey(bk => bk.BookId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
