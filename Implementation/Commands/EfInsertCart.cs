using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application;
using Microsoft.EntityFrameworkCore;

namespace Implementation.Commands
{
    public class EfInsertCart : ICartInsertCommand
    {
        private readonly Context _context;
        private readonly IApplicationActor _actor;
        public EfInsertCart(Context context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }
        public int Id => 2;

        public string Name => "Cart item insert";

        public void Execute(CartInsertDto request)
        {
   

            if (_context.Carts.Find(_actor.Id) == null)
            {
                var tmpCart = new Cart
                {
                    UserId = _actor.Id,
                    CartItems = new List<CartItem> { new CartItem { Quantity = request.Quantity, BookId = request.BookId } }
                };

                _context.Carts.Add(tmpCart);
         
            }
            else
            {
                var Id = _context.Carts.Find(_actor.Id).Id;
                _context.CartItems.Add(new CartItem { BookId = request.BookId, Quantity = request.Quantity, CartId = Id });
            }


            _context.SaveChanges();
        }
    }
}

