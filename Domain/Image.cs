using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Image : Entity
    {
        public string Src { get; set; }

        public string Alt { get; set; }

        public int BookId { get; set; }

       
        public Book Book { get; set; }
    }
}
