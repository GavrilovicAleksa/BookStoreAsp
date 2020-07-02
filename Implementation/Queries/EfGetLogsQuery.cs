using Application.DataTransfer;
using Application.Filters;
using Application.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly Context context;

        public EfGetLogsQuery(Context context)
        {
            this.context = context;
        }
        public int Id => 4;

        public string Name => "Get user logs";

        public GetAllResponse<LogDto> Execute(LogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (search.StartDate != null || search.EndDate != null)
            {
                query = query.Where(obj => obj.Date >= search.StartDate && obj.Date <= search.EndDate);
            }

            var reponse = new GetAllResponse<LogDto>
            {
                Items = query.Select(log => new LogDto
                {
                    Actor = log.Actor,
                    Data = log.Data,
                    Date = log.Date,
                    UseCaseName = log.UseCaseName
                })
            };

            return reponse;
        }
    }
}
