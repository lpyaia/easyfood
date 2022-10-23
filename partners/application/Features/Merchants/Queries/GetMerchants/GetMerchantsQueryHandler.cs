using AutoMapper;
using Easyfood.Partners.Application.Abstractions.Persistence;
using Easyfood.Partners.Application.Models.Merchants;
using Easyfood.Partners.Application.Services.Interfaces;
using Easyfood.Partners.Domain.Entities;
using Easyfood.Shared.Common.User;
using MediatR;

namespace Easyfood.Partners.Application.Features.Merchants.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, IEnumerable<MerchantDto>>
    {
        private readonly IPartnersDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRouteApi _routeApi;
        private readonly UserService userService;

        public GetMerchantsQueryHandler
        (
            IPartnersDbContext dbContext,
            IMapper mapper,
            IRouteApi routeApi,
            UserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _routeApi = routeApi;
            this.userService = userService;
        }

        public async Task<IEnumerable<MerchantDto>> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var merchants = _dbContext
                                .Set<Merchant>()
                                .Skip(request.Page * 10)
                                .Take(10)
                                .ToList();

            IEnumerable<Task<MerchantDto>> merchantsDtoTasks = merchants.Select(async (merchant) =>
            {
                DeliveryDto merchantDelivery = await _routeApi.GetDistance(UserService.Id, merchant.Address.Location, userService.Location);
                return new MerchantDto(merchant.Id, merchant.CompanyName, merchant.CompanyCategory.ToString(), merchant.CompanyLogo, merchantDelivery);
            });

            MerchantDto[] merchantsDto = await Task.WhenAll(merchantsDtoTasks);

            return merchantsDto;
        }
    }
}