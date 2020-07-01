using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class City : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

        public virtual ICollection<Publisher> Publishers { get; set; } = new HashSet<Publisher>();
    }
}
