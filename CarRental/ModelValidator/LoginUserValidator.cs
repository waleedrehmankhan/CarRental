using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class LoginUserValidator: AbstractValidator<LoginUserDto>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
