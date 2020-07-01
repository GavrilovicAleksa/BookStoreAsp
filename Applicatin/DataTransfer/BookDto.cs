using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }
        public int Year { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<string> Publishers { get; set; }

        public IEnumerable<string> AuthorsNames { get; set; }
    }
}
