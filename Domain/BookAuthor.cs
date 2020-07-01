using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Author Author { get; set; }


    }
}
