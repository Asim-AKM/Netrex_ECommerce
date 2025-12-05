using Application_Service.DTO_s.UserManagmentDto_s;
using FluentValidation;

namespace Application_Service.DTO_s.Validator
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid Email Address");

            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password Must be 8 Degits");
        }
    }
}
