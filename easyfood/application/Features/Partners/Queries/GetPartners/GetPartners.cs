using Easyfood.Application.Services.Interfaces;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Enums;
using Easyfood.Shared.Common.Request;
using Easyfood.Shared.Common.Response;
using Easyfood.Shared.Common.User;
using FluentValidation;
using MediatR;

namespace Easyfood.Application.Features.Partners.Queries.GetPartners
{
    public record GetPartnersQuery(int Page, CompanyType[]? CompanyTypes, string? Search, Guid[]? TagsId) : IRequest<PaginatedResponseData<PartnerDto[]>>;

    public record PartnerDto(Guid Id, string CompanyName, string CompanyType, string PartnerLogo, decimal Score, DeliveryDto Delivery);

    public class GetPartnersQueryValidator : AbstractValidator<GetPartnersQuery>
    {
        public GetPartnersQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
        }
    }

    public class GetPartnersQueryHandler : IRequestHandler<GetPartnersQuery, PaginatedResponseData<PartnerDto[]>>
    {
        private readonly IPartnerRepository _repository;
        private readonly IRouteApi _routeApi;
        private readonly UserService _userService;

        public GetPartnersQueryHandler
        (
            IPartnerRepository repository,
            IRouteApi routeApi,
            UserService userService)
        {
            _repository = repository;
            _routeApi = routeApi;
            _userService = userService;
        }

        public async Task<PaginatedResponseData<PartnerDto[]>> Handle(GetPartnersQuery request, CancellationToken cancellationToken)
        {
            var partners = await _repository.GetActiveParnersPaginatedAsync(request.Page,
                PaginationRequest.PageSize,
                request.Search,
                request.CompanyTypes,
                request.TagsId,
                cancellationToken);

            var count = await _repository.GetActiveParnersCountAsync(request.Search,
                request.CompanyTypes,
                request.TagsId,
                cancellationToken);

            IEnumerable<Task<PartnerDto>> merchantsDtoTasks = partners.Select(async (partner) =>
            {
                DeliveryDto merchantDelivery = await _routeApi
                    .GetDistance(UserService.Id, partner.Id, partner.Address.Location, _userService.Location);

                return new PartnerDto(partner.Id,
                    partner.CompanyName,
                    partner.CompanyCategory.ToString(),
                    partner.CompanyLogo,
                    partner.Score.Value,
                    merchantDelivery);
            });

            PartnerDto[] merchantsDto = await Task.WhenAll(merchantsDtoTasks);

            return PaginatedResponseData.Response(merchantsDto, count, request.Page);
        }
    }
}