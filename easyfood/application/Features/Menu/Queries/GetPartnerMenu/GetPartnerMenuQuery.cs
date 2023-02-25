using MediatR;

namespace Easyfood.Application.Features.Menu.Queries.GetPartnerMenu
{
    public record GetPartnerMenuQuery(Guid MerchantId) : IRequest<GetPartnerMenuDto>;
}