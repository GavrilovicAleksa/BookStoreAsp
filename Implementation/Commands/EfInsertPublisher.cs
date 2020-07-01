using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfInsertPublisher : IPublisherInsertCommand
    {
        private readonly Context _context;

        public EfInsertPublisher(Context context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Insert a book publisher";

        public void Execute(PublisherInsertDto request)
        {
            var publisher = new Publisher
            {
                Name = request.Name,
                Address = request.Address,
                CityId = request.CityId,
                PhoneNumber = request.PhoneNumber
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }
    }
}

