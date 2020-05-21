using CarRental.Dtos;
using FluentValidation;

namespace CarRental.ModelValidator
{
    public class BranchValidator : AbstractValidator<BranchDto>
    {
        public BranchValidator()
        {
            RuleFor(x => x.BranchName).NotNull().NotEmpty();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(x => x.Unit).NotNull().NotEmpty();
            RuleFor(x => x.Street).NotNull().NotEmpty();
            RuleFor(x => x.Suburb).NotNull().NotEmpty();
            RuleFor(x => x.ZipCode).NotNull().NotEmpty();
            RuleFor(x => x.City).NotNull().NotEmpty();
            RuleFor(x => x.State).NotNull().NotEmpty();
        }
    }
}