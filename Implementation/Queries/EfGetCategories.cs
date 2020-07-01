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
    public class EfGetCategories : IGetCategoriesQuery
    {
        private readonly Context context;

        public EfGetCategories(Context context)
        {
            this.context = context;
        }
        public int Id => 3;

        public string Name => "Get list of categories";
        public GetAllResponse<CategoryDto> Execute(GetAll search)
        {
            var categories = context.Categories.AsQueryable();

            var reponse = new GetAllResponse<CategoryDto>
            {
                Items = categories.Select(x => new CategoryDto
                {
                   Id = x.Id,
                   Name = x.Name
                }).ToList()
            };

            return reponse;
        }

    }
}
