using Easyfood.Partners.Application.Models.Merchants;
using MediatR;

namespace Easyfood.Partners.Application.Features.Merchants.Queries.GetMerchants
{
    public class GetMerchantsQuery : IRequest<IEnumerable<MerchantDto>>
    {
        public int Page { get; set; }
    }
}