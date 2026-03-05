namespace Application_Service.DTO_s.Validators.PaymentAndPayout
{
    public class ProductReviewDtoValidator: AbstractValidator<AddProductReviewsDto>
    {
        public ProductReviewDtoValidator()
        {
            RuleFor(x => x.ReviewId)
               .NotEmpty().WithMessage("ReviewId is required.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");

            //RuleFor(x => x.Comment)
            //    .NotEmpty().WithMessage("Comment is required.")
            //    .MinimumLength(5).WithMessage("Comment must be at least 5 characters.")
            //    .MaximumLength(500).WithMessage("Comment must not exceed 500 characters.");

            //RuleFor(x => x.CreatedAt)
            //    .NotEmpty().WithMessage("CreatedAt is required.")
            //    .LessThanOrEqualTo(DateTime.UtcNow)
            //    .WithMessage("CreatedAt cannot be in the future.");

            //RuleFor(x => x.IPAddress)
            //    .NotEmpty().WithMessage("IP Address is required.")
            //    .Matches(@"^(\d{1,3}\.){3}\d{1,3}$")
            //    .WithMessage("Invalid IP Address format.");

            //RuleFor(x => x.IsApproved)
            //    .NotNull().WithMessage("Approval status must be specified.");
        }
    }
    
}
