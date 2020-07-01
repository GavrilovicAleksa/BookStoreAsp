using Application;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly Context _context;

        public DatabaseUseCaseLogger(Context context) => _context = context;

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            //_context.UseCaseLogs.Add(new Domain.UseCaseLog
            //{
            //    Actor = actor.Identity,
            //    Data = JsonConvert.SerializeObject(useCaseData),
            //    Date = DateTime.UtcNow,
            //    UseCaseName = useCase.Name
            //});

            //_context.SaveChanges();
        }
    }
}
