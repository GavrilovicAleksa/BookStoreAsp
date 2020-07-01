using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validation
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserValidator(Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(user => user.Username == x))
                .WithMessage("Username is already taken.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.CityId)
                .NotEmpty()
                .Must(id => context.Cities.Any(x => x.Id == id))
                .WithMessage("City doesnt exist.");


        }
    }
}
