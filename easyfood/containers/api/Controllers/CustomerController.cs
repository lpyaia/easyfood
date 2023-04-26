using Easyfood.Api.Attributes;
using Easyfood.Application.Features.Customers.Commands.CreateCreditCard;
using Easyfood.Application.Features.Customers.Commands.CreateNewCustomer;
using Easyfood.Application.Features.Customers.Queries.GetCreditCards;
using Easyfood.Shared.Authorization.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SubscriptionKeyAuthorization]
        public async Task<IActionResult> RegisterUser([FromHeader(Name = "subscription-key")] string _,
            [FromBody] CreateNewCustomerDto newCustomer, CancellationToken cancellationToken)
        {
            var cmd = new CreateNewCustomerCommand(newCustomer.UserId,
                newCustomer.UserName,
                newCustomer.Email,
                newCustomer.FirstName,
                newCustomer.LastName,
                newCustomer.BirthDate);

            await _mediator.Send(cmd, cancellationToken);

            return Created("/", null);
        }

        [HttpGet("/api/customers/{id}/credit-cards")]
        [JwtAuthorization]
        public async Task<IActionResult> GetCreditCards([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCreditCardsQuery(id), cancellationToken);

            return Ok(result);
        }

        [HttpPost("/api/customers/{id}/credit-cards")]
        [JwtAuthorization]
        public async Task<IActionResult> CreateCreditCard([FromRoute] Guid id, [FromBody] CreateCustomerCreditCardDto body, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateCustomerCreditCardCommand(id,
                body.Number,
                body.CardholderFirstName,
                body.CardholderLastName,
                body.ExpirationDate,
                body.CVCCode), cancellationToken);

            return Created("/checkout", null);
        }
    }
}