using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;
using MediatR;

namespace Easyfood.Application.Features.Menu.Queries.GetPartnerMenu
{
    public class GetPartnerMenuHandler : IRequestHandler<GetPartnerMenuQuery, GetPartnerMenuDto>
    {
        private readonly IRepository<Partner> _repository;

        public GetPartnerMenuHandler(IRepository<Partner> repository)
        {
            _repository = repository;
        }

        public Task<GetPartnerMenuDto> Handle(GetPartnerMenuQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}