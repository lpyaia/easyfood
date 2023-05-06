using Easyfood.Application.Features.Partners.Queries.GetMenu;
using Easyfood.Application.Features.Partners.Queries.GetPartners;
using Easyfood.Shared.Authorization.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Api.Controllers
{
    [Route("api/partners")]
    [JwtAuthorization]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PartnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPartnersQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("/api/partners/{id}/menu")]
        public async Task<IActionResult> GetPartnerMenu([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetMenuQuery(id));

            return Ok(result);
        }
    }
}