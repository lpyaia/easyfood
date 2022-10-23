using MediatR;

namespace Easyfood.Partners.Application.Features.Menu.Queries.GetMerchantMenu
{
    public record GetMerchantMenuQuery(Guid MerchantId) : IRequest<GetMerchantMenuDto>;
}