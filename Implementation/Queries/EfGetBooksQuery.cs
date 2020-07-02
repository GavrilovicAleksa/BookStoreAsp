using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetBooksQuery : IGetBooksQuery
    {
        private readonly Context context;

        public EfGetBooksQuery(Context context)
        {
            this.context = context;
        }

        public int Id => 4;

        public string Name => "Book filter and search";

        public PagedResponse<BookDto> Execute(BookFilter filter)
        {
            var query = context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title) || !string.IsNullOrWhiteSpace(filter.Title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(filter.Title.ToLower()));
            }

            if (filter.CategoryId != null)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }

            if(filter.AuthorId != null)
            {
                query = query.Where(x => x.BookAuthors.Select(ba => ba.Author).Where(ba => ba.Id == filter.AuthorId).FirstOrDefault());
            }

            var skipCount = filter.PerPage * (filter.Page - 1);

            var reponse = new PagedResponse<BookDto>
            {
                CurrentPage = filter.Page,
                BooksPerPage = filter.PerPage,
                TotalCount = query.Count(),
                Books = query.Skip(skipCount).Take(filter.PerPage).Select(x => new BookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.BookPublishers.Select(bp => bp.Price).FirstOrDefault(),
                    CategoryName = x.Category.Name,
                    Publishers = x.BookPublishers.Select(bp => bp.Publisher.Name),
                    AuthorsNames = x.BookAuthors.Select(ba => ba.Author.FirstName),
                    Src = x.Image.Src,
                    Alt = x.Image.Alt
                    
                }).ToList()
            };

            return reponse;
        }
    }
}
