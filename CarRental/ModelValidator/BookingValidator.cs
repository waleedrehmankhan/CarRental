using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {

            RuleFor(x => x.FromBranchID).NotNull().NotEmpty();
            RuleFor(x => x.ToBranchID).NotNull().NotEmpty();
            RuleFor(x => x.FromDate).NotNull().NotEmpty();
            RuleFor(x => x.ReturnDate).NotNull().NotEmpty();
            RuleFor(x => x.ActualReturnDate).NotNull().NotEmpty();
            RuleFor(x => x.CustomerId).NotNull().NotEmpty();
            RuleFor(x => x.CarId).NotNull().NotEmpty();
        }
    }
}
