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
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("UserIdentifier cannot be whitespace");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password required")
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Password cannot be whitespace");
        }
    }
}
