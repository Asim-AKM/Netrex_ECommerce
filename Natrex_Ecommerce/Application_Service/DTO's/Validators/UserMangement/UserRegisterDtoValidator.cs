using Application_Service.DTO_s.UsersDto.Accounts;
using FluentValidation;

namespace Application_Service.DTO_s.Validators.UserMangement
{
    public class UserRegisterDtoValidator : AbstractValidator<CreateUserDto>
    {
        public UserRegisterDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(30).WithMessage("Full name must not exceed 30 characters.")
                .Must(name => name == name?.Trim())
                    .WithMessage("Full name must not contain leading or trailing spaces.")
                .Matches(@"^[A-Za-z]+( [A-Za-z]+)*$")
                    .WithMessage("Full name can contain only letters and single spaces.");


            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName Required")
                .NotNull().WithMessage("UserName is null");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password Must be 8 Degits");

        }
    }
}
