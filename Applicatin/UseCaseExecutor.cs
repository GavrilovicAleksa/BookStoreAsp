using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            logger.Log(query, actor, search);

            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, actor);
            }

            return query.Execute(search);
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            logger.Log(command, actor, request);
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);

        }
    }
}
