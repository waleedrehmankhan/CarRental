using CarRental.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ModelValidator
{
    public class PaymentValidator: AbstractValidator<PaymentDto>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.PaymentType).NotNull().NotEmpty();
            RuleFor(x => x.PaymentDate).NotNull().NotEmpty();
            RuleFor(x => x.TotalAmount).NotNull().NotEmpty();
         

            RuleFor(x => x.PaymentDate).Custom((x, context) => {
                if (!Helpers.Utility.BeAValidDate(x.ToString()))
                {
                    context.AddFailure("Payment Date is not valid Date");
                }
            });
        }
    }
}
