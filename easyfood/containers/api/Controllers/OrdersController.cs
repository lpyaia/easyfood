using Easyfood.Application.Features.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto body, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateOrderCommand(body.CustomerId, body.PartnerId, body.CreditCardId, body.Items));

            return Ok(response);
        }
    }
}