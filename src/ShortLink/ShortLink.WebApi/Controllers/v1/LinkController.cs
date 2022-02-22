using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ShortLink.Service.Features.Links.Commands;
using ShortLink.Service.Features.Links.Dtos;
using ShortLink.Service.Features.Links.Queries;
using System.Threading.Tasks;

namespace ShortLink.Api.Controllers.v1
{
    public class LinkController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public LinkController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateShortLinkCommand command)
        {
            var result = await _mediator.Send(command);
            var url = _configuration.GetValue<string>("UrlSetting:Url");

            return Ok(url + "/"+ result.ShortLink);
        }

        [HttpGet("{shortlink}")]
        public async Task<ActionResult> Get(string shortlink)
        {
            var qeury = new GetLinkQuery() { ShortLink = shortlink };
            var result = await _mediator.Send(qeury);

            if (result == null)
            {
                return NotFound();
            }

            return Redirect(result.MainLink);
        }

        [HttpGet("[Action]{shortlink}")]
        public async Task<ActionResult<int>> GetVisitCount(string shortlink)
        {
            var qeury = new GetVisitCountQuery() { ShortLink = shortlink };
            var result = await _mediator.Send(qeury);
            return Ok(result);
        }
    }
}
