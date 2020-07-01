using Application;
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
    public class EfGetPublishersQuery : IGetPublishersQuery
    {
        private readonly Context context;

        public EfGetPublishersQuery(Context context)
        {
            this.context = context;
        }
        public int Id => 3;

        public string Name => "Get list of publisher";
        public GetAllResponse<PublisherDto> Execute(GetAll search)
        {
            var publishers = context.Publishers.AsQueryable();

            var reponse = new GetAllResponse<PublisherDto>
            {
                Items = publishers.Select(x => new PublisherDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList()
            };

            return reponse;
        }

      
    }
}
