using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Domain.Entities.Partners;
using Easyfood.Shared.Common.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Easyfood.Application.Features.Partners.Queries.GetMenu
{
    public record GetMenuDto(Guid Id,
        Guid PartnerId,
        Guid MenuId,
        string Name,
        string Description,
        string Image,
        decimal Price);

    public record GetMenuQuery(Guid PartnerId) : IRequest<ResponseData<List<GetMenuDto>>>;

    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, ResponseData<List<GetMenuDto>>>
    {
        private readonly IEasyfoodDbContext _easyfoodDbContext;

        public GetMenuQueryHandler(IEasyfoodDbContext easyfoodDbContext)
        {
            _easyfoodDbContext = easyfoodDbContext;
        }

        public async Task<ResponseData<List<GetMenuDto>>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            var data = await _easyfoodDbContext.Set<MenuItem>()
                                                 .Where(x => x.Menu.PartnerId == request.PartnerId)
                                                 .Select(x => new GetMenuDto(x.Id,
                                                     request.PartnerId,
                                                     x.Menu.Id,
                                                     x.ItemName,
                                                     x.Description,
                                                     x.Image,
                                                     x.Price.Value))
                                                 .ToListAsync(cancellationToken);

            return new ResponseData<List<GetMenuDto>>(data);
        }
    }
}