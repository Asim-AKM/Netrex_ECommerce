using Application_Service.DTO_s.ShopDetailsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.Validators.SellerAndShopDetails
{
    public class UpdateShopDetailsValidator:AbstractValidator<UpdateShopDetailsDto>
    {
        public UpdateShopDetailsValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.ShopDetailsId)
                .NotEmpty().WithMessage("ShopDetailsId Required")
                .NotNull().WithMessage("ShopDetailsId can't Null");
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name Required")
                .NotNull().WithMessage("Category Name can't Null")
                .MaximumLength(50).WithMessage("Category Name must not exceed 50 characters.")
                .Must(name => name == name?.Trim())
                .WithMessage("Category Name must not contain leading or trailing spaces.")
                .Matches(@"^[A-Za-z0-9]+( [A-Za-z0-9]+)*$")
                .WithMessage("Category Name can contain only letters, numbers and single spaces.");
        }
    }
}
