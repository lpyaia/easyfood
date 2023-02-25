using FluentValidation;

namespace Easyfood.Application.Features.Partners.Queries.GetPartners
{
    public class GetPartnersQueryValidator : AbstractValidator<GetPartnersQuery>
    {
        public GetPartnersQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
        }
    }
}