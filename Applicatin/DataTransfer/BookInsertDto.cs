using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class BookInsertDto
    {
        public string Title { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public int PublisherId { get; set; }

        public int AuthorId { get; set; }

        public string Src { get; set; }
    }
}
