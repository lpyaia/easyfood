using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Domain.Entities.Customers;
using Easyfood.Shared.Common.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Easyfood.Application.Features.Customers.Queries.GetCreditCards
{
    public record GetCreditCardsQuery(Guid CustomerId) : IRequest<ResponseData<IList<GetCreditCardDto>>>;

    public record GetCreditCardDto(Guid CreditCardId, string CreditCardNumber, CreditCardFlag CreditCardFlag);

    public class GetCreditCardsHandler : IRequestHandler<GetCreditCardsQuery, ResponseData<IList<GetCreditCardDto>>>
    {
        private readonly IEasyfoodDbContext _context;

        public GetCreditCardsHandler(IEasyfoodDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseData<IList<GetCreditCardDto>>> Handle(GetCreditCardsQuery request, CancellationToken cancellationToken)
        {
            var creditCards = await _context.Set<CreditCard>()
                                            .Where(c => c.CustomerId == request.CustomerId)
                                            .AsNoTracking()
                                            .ToListAsync(cancellationToken);

            var data = creditCards.Select(cc => new GetCreditCardDto(cc.Id, cc.DisplayNumber, cc.Flag))
                                  .ToList();

            return new ResponseData<IList<GetCreditCardDto>>(data);
        }
    }
}