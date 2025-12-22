using Application_Service.DTO_s.PaymentAndPayoutDtos;
using FluentValidation;

namespace Application_Service.DTO_s.Validators.PaymentAndPayout
{
   internal class InvoiceDtoValidator : AbstractValidator<InvoiceDto>
    {
        public InvoiceDtoValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("OrderId is required")
                .NotEqual(Guid.Empty).WithMessage("OrderId cannot be an empty GUID");
                 RuleFor(x => x.Total)
                .GreaterThan(0).WithMessage("Total must be greater than zero");

        }

    }
}
