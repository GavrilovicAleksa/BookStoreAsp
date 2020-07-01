using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cart : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();

    }
}
