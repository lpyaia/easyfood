using Easyfood.Partners.Application.Models.Merchants;
using FluentValidation;

namespace Easyfood.Partners.Application.Validators
{
    public class MerchantValidator : AbstractValidator<MerchantDto>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.CompanyType).NotEmpty();
        }
    }
}