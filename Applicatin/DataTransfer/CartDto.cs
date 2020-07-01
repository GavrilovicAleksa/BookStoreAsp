using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CartDto
    { 
        public int Id { get; set; }

        public int Quanity { get; set; }

        public object Book { get; set; }
    }
}
