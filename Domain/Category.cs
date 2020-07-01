using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }

        // public int ParentId { get; set; } Ako bude bilo potkategorija

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
