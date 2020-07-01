using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Validation
{
    public class BookInsertValidator : AbstractValidator<BookInsertDto>
    {

        public BookInsertValidator(Context context)
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.PublisherId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
           
        }
    }
}
