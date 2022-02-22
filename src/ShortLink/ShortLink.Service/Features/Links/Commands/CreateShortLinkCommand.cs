using MediatR;
using ShortLink.Domain;
using ShortLink.Domain.Links;
using ShortLink.Service.Features.Links.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace ShortLink.Service.Features.Links.Commands
{
    public partial class CreateShortLinkCommand : IRequest<ShortLinkDto>
    {
        public string MainLink { get; set; }

        private class Handler : IRequestHandler<CreateShortLinkCommand, ShortLinkDto>
        {
            private readonly IWriteRepository<Link> _linkRepository;
            private readonly IMediator _mediator;
            public Handler(IWriteRepository<Link> linkRepository, IMediator mediator)
            {
                _linkRepository = linkRepository;
                _mediator = mediator;
            }

            public async Task<ShortLinkDto> Handle(CreateShortLinkCommand command, CancellationToken cancellationToken)
            {
                var shortLink = await _mediator.Send(new GeneratNewShortLinkCommand());

                var link = new Link(command.MainLink, shortLink);
                await _linkRepository.CreateAsync(link);
                await _linkRepository.SaveChangeAsync();

                return new ShortLinkDto { ShortLink = shortLink};
            }
        }
    }
}