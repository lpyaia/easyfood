using Easyfood.Api.Attributes;
using Easyfood.Application.Features.Customers.Commands.CreateNewCustomer;
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
    }
}