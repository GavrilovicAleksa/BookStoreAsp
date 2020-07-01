using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetAllResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

    }
}
