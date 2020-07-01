using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Publisher : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<BookPublisher> BookPublishers { get; set; } = new HashSet<BookPublisher>();

    }
}
