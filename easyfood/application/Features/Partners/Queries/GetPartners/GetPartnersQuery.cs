using Easyfood.Application.Models.Partners;
using Easyfood.Shared.Common.Response;
using MediatR;

namespace Easyfood.Application.Features.Partners.Queries.GetPartners
{
    public class GetPartnersQuery : IRequest<PaginatedResponseData<PartnerDto[]>>
    {
        public int Page { get; set; }
    }
}