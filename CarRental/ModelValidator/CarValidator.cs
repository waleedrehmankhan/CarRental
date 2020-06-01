using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotNull().NotEmpty();
            RuleFor(x => x.Year).NotNull().NotEmpty();
            RuleFor(x => x.Make).NotNull().NotEmpty();
            RuleFor(x => x.Model).NotNull().NotEmpty();
            RuleFor(x => x.Mileage).NotNull().NotEmpty();
            RuleFor(x => x.isAvailable).NotNull().NotEmpty();
            RuleFor(x => x.isActive).NotNull().NotEmpty();
            RuleFor(x => x.CarClassification).SetValidator(new CarClassificationValidator());
        }
    }
}
