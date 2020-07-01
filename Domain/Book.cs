using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
        public virtual ICollection<BookPublisher> BookPublishers { get; set; } = new HashSet<BookPublisher>();
    }
}
