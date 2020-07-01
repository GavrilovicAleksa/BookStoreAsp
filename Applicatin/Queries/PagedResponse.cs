using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int BooksPerPage { get; set; }
        public IEnumerable<T> Books { get; set; }

        public int PagesCount => (int)Math.Ceiling((float)TotalCount / BooksPerPage);
    }
}
