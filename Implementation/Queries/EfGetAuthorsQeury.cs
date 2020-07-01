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
    public class EfGetAuthorsQeury : IGetAuthorsQuery
    {
        private readonly Context context;

        public EfGetAuthorsQeury(Context context)
        {
            this.context = context;
        }
        public int Id => 3;

        public string Name => "Get list of authors";
        public GetAllResponse<AuthorDto> Execute(GetAll search)
        {
            var authors = context.Authors.AsQueryable();

            var reponse = new GetAllResponse<AuthorDto>
            {
                Items = authors.Select(x => new AuthorDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList()
            };

            return reponse;
        }
    }
}
