using Easyfood.Application.Features.Partners.Queries.GetTags;
using Easyfood.Shared.Authorization.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Api.Controllers
{
    [Route("api/partners/tags")]
    [JwtAuthorization]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetTagsQuery());

            return Ok(result);
        }
    }
}