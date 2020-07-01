using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CartItem : Entity
    {
        public int Quantity { get; set; }

        public int BookId { get; set; }

        public int CartId { get; set; }


        public virtual Book Book { get; set; }

        public virtual Cart Cart { get; set; }

    }
}
