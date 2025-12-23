using Application_Service.DTO_s.PaymentAndPayoutDtos;
using FluentValidation;
using System;

namespace Application_Service.DTO_s.Validators.PaymentAndPayout
{
    public class AddSellerPayoutDtoValidator : AbstractValidator<AddSellerPayoutDto>
    {
        public AddSellerPayoutDtoValidator()
        {
            RuleFor(x => x.SellerId)
                .NotEmpty().WithMessage("SellerId is required")
                .NotEqual(Guid.Empty).WithMessage("SellerId cannot be an empty GUID");

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required")
                .NotEqual(Guid.Empty).WithMessage("OrderId cannot be an empty GUID");

            RuleFor(x => x.AmountToPay)
                .GreaterThan(0).WithMessage("AmountToPay must be greater than zero");
        }
    }
}
