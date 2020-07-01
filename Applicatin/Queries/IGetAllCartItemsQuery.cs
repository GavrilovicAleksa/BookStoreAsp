using Application.DataTransfer;
using Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetAllCartItemsQuery : IQuery<GetAll, GetAllResponse<CartDto>>
    {
    }
}
