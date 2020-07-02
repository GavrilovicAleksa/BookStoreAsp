using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer;
using Application.Filters;

namespace Application.Queries
{
    public interface IGetLogsQuery : IQuery<LogSearch, GetAllResponse<LogDto>>
    {
    }
}
