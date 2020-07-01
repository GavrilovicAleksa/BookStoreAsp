using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymus User";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 15);
    }
}
