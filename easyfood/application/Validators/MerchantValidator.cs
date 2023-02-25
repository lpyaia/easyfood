using Easyfood.Application.Models.Partners;
using FluentValidation;

namespace Easyfood.Application.Validators
{
    public class PartnerValidator : AbstractValidator<PartnerDto>
    {
        public PartnerValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.CompanyType).NotEmpty();
        }
    }
}