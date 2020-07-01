using Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class BookFilter : PagedSearch
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public string PriceOrder { get; set; }

        public string TitleOrder { get; set; }
    }
}
