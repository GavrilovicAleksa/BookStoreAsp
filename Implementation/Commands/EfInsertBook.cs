using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfInsertBook : IBookInsertCommand
    {
        private readonly Context _context;

        public EfInsertBook(Context context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Insert a book";

        public void Execute(BookInsertDto request)
        {
            var book = new Book
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                Image = new Image { Src = request.Src}
            };

            var bookpublisher = new BookPublisher
            {
                Price = request.Price,
                PublisherId = request.PublisherId,
                Book = book
            };

            var bookauthor = new BookAuthor
            {
                Book = book,
                AuthorId = request.AuthorId
            };

            book.BookPublishers.Add(bookpublisher);
            book.BookAuthors.Add(bookauthor);

            _context.Books.Add(book);

            _context.SaveChanges();
        }
    }
}
