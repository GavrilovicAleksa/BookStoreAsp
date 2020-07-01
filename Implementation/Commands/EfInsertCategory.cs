using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfInsertCategory : ICategoryInsertCommand
    {
        private readonly Context _context;

        public EfInsertCategory(Context context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Insert a category";

        public void Execute(CategoryInsertDto request)
        {
            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
