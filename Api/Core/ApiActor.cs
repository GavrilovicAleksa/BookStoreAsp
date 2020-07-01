using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class ApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Logged User";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(15,15);
    }

    public class FakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Admin User";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1,50);
    }
}
