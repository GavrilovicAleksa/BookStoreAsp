using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfInsertAuthor : IAuthorInsertCommand
    {
        private readonly Context _context;

        public EfInsertAuthor(Context context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Insert a book author";

        public void Execute(AuthorInsertDto request)
        {
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

           _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
}
