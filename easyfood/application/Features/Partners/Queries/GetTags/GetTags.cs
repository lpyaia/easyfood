using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Application.Models;
using Easyfood.Domain.Entities.Partners;
using Easyfood.Shared.Common.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Easyfood.Application.Features.Partners.Queries.GetTags
{
    public class GetTagsQuery : IRequest<ResponseData<List<TagDto>>>
    {
    }

    public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, ResponseData<List<TagDto>>>
    {
        private readonly IEasyfoodDbContext _context;

        public GetTagsQueryHandler(IEasyfoodDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseData<List<TagDto>>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Set<Tag>().ToListAsync();
            var result = tags.Select(x => new TagDto(x.Id, x.Name)).ToList();

            return new ResponseData<List<TagDto>>(result);
        }
    }
}