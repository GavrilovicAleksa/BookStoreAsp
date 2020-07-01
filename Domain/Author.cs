using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Author : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
    }
}
