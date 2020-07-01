using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserUserCase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
    }
}
