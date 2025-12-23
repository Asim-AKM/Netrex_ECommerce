using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Domain_Service.Enums;
using FluentValidation;
using System;

namespace Application_Service.DTO_s.Validators.PaymentAndPayout
{
    public class ProcessPaymentDtoValidator : AbstractValidator<ProcessPaymentDto>
    {
        public ProcessPaymentDtoValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required")
                .NotEqual(Guid.Empty).WithMessage("OrderId cannot be an empty GUID");

            RuleFor(x => x.PaymentMethod)
                .IsInEnum().WithMessage("Invalid payment method");

            RuleFor(x => x.AmountPaid)
                .GreaterThan(0).WithMessage("AmountPaid must be greater than zero");
        }
    }
}
