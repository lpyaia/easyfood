using Easyfood.Partners.Application.Features.Merchants.Queries.GetMerchants;
using Easyfood.Shared.Authorization.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Partners.Api.Controllers
{
    [Route("api/merchants")]
    [JwtAuthorization()]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetMerchantsQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}