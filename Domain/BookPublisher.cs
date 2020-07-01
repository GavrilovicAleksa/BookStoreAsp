using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BookPublisher 
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int BookId { get; set; }

        public int PublisherId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
