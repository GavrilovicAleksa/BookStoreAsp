using Application.DataTransfer;
using Application.Filters;
using Application.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetSingleBook : IGetSingleProductQuery

    {
        private readonly Context context;

        public EfGetSingleBook(Context context)
        {
            this.context = context;
        }
        public int Id => 2;
        public string Name => "Select a single book";

        public GetSingleResult Execute(GetOne search)
        {
            var book = context.Books.AsQueryable();

            var reponse = new GetSingleResult
            {
                Item = book.Select(x => new BookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.BookPublishers.Select(bp => bp.Price).FirstOrDefault(),
                    CategoryName = x.Category.Name,
                    Publishers = x.BookPublishers.Select(bp => bp.Publisher.Name),
                    AuthorsNames = x.BookAuthors.Select(ba => ba.Author.FirstName),
                    Src = x.Image.Src,
                    Alt = x.Image.Alt
                }).Where(b => b.Id == search.Id).FirstOrDefault()
            };

            return reponse;
        }
    }
}
