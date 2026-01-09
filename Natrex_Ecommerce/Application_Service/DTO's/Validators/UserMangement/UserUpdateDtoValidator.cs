using Application_Service.DTO_s.UserManagmentDto_s;
using FluentValidation;

namespace Application_Service.DTO_s.Validators.UserMangement
{
    public class UserUpdateDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UserUpdateDtoValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("User Id is required");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MaximumLength(100).WithMessage("Full name max 100 characters");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(50).WithMessage("Username max 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Contact)
                .NotEmpty().WithMessage("Contact is required")
                .WithMessage("Invalid phone number");

        }
    }
}
