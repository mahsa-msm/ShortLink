using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Service.Features.Links.Commands;
using ShortLink.Service.Features.Links.Dtos;
using System.Threading.Tasks;

namespace ShortLink.Api.Controllers.v1
{
    public class LinkController : BaseApiController
    {
        private readonly IMediator _mediator;
        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ShortLinkDto>> Mediator(CreateShortLinkCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
