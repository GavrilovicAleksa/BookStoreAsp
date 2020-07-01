using Application.DataTransfer;
using Application.Filters;
using Application.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;

namespace Implementation.Queries
{
    public class EfGetCartItems : IGetAllCartItemsQuery
    {
        private readonly Context context;

        public EfGetCartItems(Context context)
        {
            this.context = context;
        }
        public int Id => 4;

        public string Name => "Get cart items";

        public GetAllResponse<CartDto> Execute(GetAll search)
        {
            var CartItems = context.Carts.AsQueryable();

            var reponse = new GetAllResponse<CartDto>
            {
                Items = CartItems.Select(x => new CartDto
                {
                    Id = x.Id,
                    Quanity = x.CartItems.Select(c => c.Quantity).FirstOrDefault(),
                    Book = x.CartItems.Select(c => c.Book).FirstOrDefault()
                }).ToList()
            };

            return reponse;
        }
    }
}
