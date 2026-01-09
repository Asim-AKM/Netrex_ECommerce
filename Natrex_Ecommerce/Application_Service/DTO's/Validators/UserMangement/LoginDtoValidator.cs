using Application_Service.DTO_s.UserManagmentDto_s;
using FluentValidation;

namespace Application_Service.DTO_s.Validators.UserMangement
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator() 
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserIdentifier)
                .NotEmpty().WithMessage("UserIdentifier Required")
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required")
                .NotNull().WithMessage("Password should not null");
        }
    }
}
