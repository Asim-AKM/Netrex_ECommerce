using Application_Service.DTO_s.SellerDtos;
using FluentValidation;

namespace Application_Service.DTO_s.Validators
{
    public class CreateSellerValidator : AbstractValidator<CreateSellerDto>
    {

        public CreateSellerValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.SellerId)
                .NotEmpty().WithErrorCode("SellerId Required")
                .NotNull().WithMessage("Seller Id can't Null");

            RuleFor(x => x.ShopId)
                .NotEmpty().WithErrorCode("ShopId Required")
                .NotNull().WithMessage("ShopId can't Null");

            RuleFor(x=>x.UserId)
                .NotEmpty().WithErrorCode("UserId Required")
                .NotNull().WithMessage("UserId can't Null");

            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Store Name Required")
                .NotNull().WithMessage("Store Name can't Null")
                .MaximumLength(30).WithMessage("Store Name must not exceed 50 characters.")
                .Must(name => name == name?.Trim())
                .WithMessage("Store Name must not contain leading or trailing spaces.")
                .Matches(@"^[A-Za-z0-9]+( [A-Za-z0-9]+)*$")
                .WithMessage("Store Name can contain only letters, numbers and single spaces.");

            RuleFor(x => x.StoreDescription)
                .NotEmpty().WithMessage("Store Description Required")
                .NotNull().WithMessage("Store Description can't Null")
                .MaximumLength(200).WithMessage("Store Description must not exceed 200 characters.")
                .Must(desc => desc == desc?.Trim())
                .WithMessage("Store Description must not contain leading or trailing spaces.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address Required")
                .NotNull().WithMessage("Address can't Null")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.")
                .Must(address => address == address?.Trim())
                .WithMessage("Address must not contain leading or trailing spaces.");
        }


    }
}
