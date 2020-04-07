using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerCode).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.MembershipTypeId).NotNull().NotEmpty();
            RuleFor(x => x.EmailAddress).NotNull().NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
            RuleFor(x => x.LicenseNumber).NotNull().NotEmpty().MaximumLength(10);

        }
    }
}
