using FluentValidation;

namespace Easyfood.Partners.Application.Features.Merchants.Queries.GetMerchants
{
    public class GetMerchantsQueryValidator : AbstractValidator<GetMerchantsQuery>
    {
        public GetMerchantsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
        }
    }
}