using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name is Required");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name is Required");
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.UserRole).NotNull().NotEmpty().WithMessage("Role is Required");
        }
    }
}
