using Easyfood.Partners.Application.Abstractions.Persistence;
using MediatR;

namespace Easyfood.Partners.Application.Features.Menu.Queries.GetMerchantMenu
{
    public class GetMerchantMenuHandler : IRequestHandler<GetMerchantMenuQuery, GetMerchantMenuDto>
    {
        private readonly IPartnersDbContext _context;

        public GetMerchantMenuHandler(IPartnersDbContext context)
        {
            _context = context;
        }

        public Task<GetMerchantMenuDto> Handle(GetMerchantMenuQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}