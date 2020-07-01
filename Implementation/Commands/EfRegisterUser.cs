using Application.Commands;
using Application.DataTransfer;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfRegisterUser : IRegisterUserCommand
    {
        private readonly Context _context;

        public EfRegisterUser(Context context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create a User";

        public void Execute(RegisterUserDto request)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                CityId = request.CityId
            };

            _context.Add(user);

            _context.SaveChanges();
        }

    }
}
