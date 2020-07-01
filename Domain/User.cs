using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int CityId { get; set; }


        public virtual City City { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

        public virtual ICollection<UserUserCase> UserUserCases { get; set; }

    }
}
