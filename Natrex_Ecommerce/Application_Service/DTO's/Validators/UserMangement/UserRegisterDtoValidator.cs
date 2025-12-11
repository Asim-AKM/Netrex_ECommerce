using Application_Service.DTO_s.UsersDto.Accounts;
using FluentValidation;

namespace Application_Service.DTO_s.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<CreateUserDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(x => x.contact)
                .Empty().WithMessage("Contact Required")
                .MaximumLength(11).WithMessage("Contact must contain 11 digits")
                .Length(11).WithMessage("Contain Atleast 11 digits")
                .Matches("[0-9]").WithMessage("Contact Only Contain digits(0-9)");

            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password Must be 8 Degits");

            RuleFor(x => x.username)
                .NotEmpty().WithMessage("UserName Required")
                .NotNull().WithMessage("UserName is null");
        }
    }
}
