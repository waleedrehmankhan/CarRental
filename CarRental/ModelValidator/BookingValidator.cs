﻿using CarRental.Dtos;
using FluentValidation;
using System;
namespace CarRental.ModelValidator
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {

            RuleFor(x => x.FromBranchID).NotNull().NotEmpty().WithMessage("Pick Up Location Cannot be Empty");
            RuleFor(x => x.ToBranchID).NotNull().NotEmpty().WithMessage("Return Location Cannot be Empty");
            RuleFor(x => x.isActive).NotNull().NotEmpty().WithMessage("Status Cannot be Empty");

            //RuleFor(x => x.FromDate).NotNull().NotEmpty().NotEqual("1970-01-01T00:00:00").WithMessage("From Date Cannot be Empty");
            //RuleFor(x => x.ReturnDate).NotNull().NotEmpty().WithMessage("Return Date Cannot be Empty");

            RuleFor(x => x.CarId).NotNull().NotEmpty().WithMessage("Car Cannot be Empty");
            RuleFor(x => x.ToBranchID).NotEqual(x => x.FromBranchID).WithMessage("Pick up Location and Drop off Location Cannot be same.");
            RuleFor(x => x.FromDate).Custom((x, context) => {
                if (!Helpers.Utility.BeAValidDate(x))
                {
                    context.AddFailure("From Date is not valid Date time");
                }
            });
            RuleFor(x => x.ReturnDate).Custom((x, context) => {
                if (!Helpers.Utility.BeAValidDate(x))
                {
                    context.AddFailure("Return Date is not valid Date time");
                }
            });

            When(x => x.Id == 0, () => { 

            RuleFor(x => x.FromDate).Custom((x, context) => {
                if (!Helpers.Utility.NotPastDate(x))
                {
                    context.AddFailure("From Date can not be past date");
                }
            });
            RuleFor(x => x.ReturnDate).Custom((x, context) => {
                if (!Helpers.Utility.NotPastDate(x))
                {
                    context.AddFailure("Return Date can not be past date");
                }
            });
            });


            When(x => x.IsNewCustomer, () =>
            {
                RuleFor(x => x.Customer.CustomerCode).NotNull().NotEmpty();
                RuleFor(x => x.Customer.FirstName).NotNull().NotEmpty();
                RuleFor(x => x.Customer.LastName).NotNull().NotEmpty();
                RuleFor(x => x.Customer.MembershipTypeId).NotNull().NotEmpty();
                RuleFor(x => x.Customer.EmailAddress).NotNull().NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);
                RuleFor(x => x.Customer.PhoneNumber).NotNull().NotEmpty();
                RuleFor(x => x.Customer.LicenseNumber).NotNull().NotEmpty().MaximumLength(10);
            });
            When(x => !x.IsNewCustomer, () =>
            {
                RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("Customer Cannot be Empty");
            });
        }
        
    }
}
