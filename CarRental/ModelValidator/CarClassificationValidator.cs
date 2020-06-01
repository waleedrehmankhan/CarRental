using CarRental.Dtos;
using FluentValidation;

namespace CarRental.ModelValidator
{
    public class CarClassificationValidator : AbstractValidator<CarClassificationDto>
    {
        public CarClassificationValidator()
        {
            RuleFor(x => x.PassengerCount).NotNull().NotEmpty();
            RuleFor(x => x.CostPerHour).NotNull().NotEmpty();
            RuleFor(x => x.CostPerDay).NotNull().NotEmpty();
            RuleFor(x => x.LateFeePerHour).NotNull().NotEmpty();

        }
    }
}