using MediatR;
using ShortLink.Domain;
using ShortLink.Domain.Links;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShortLink.Service.Features.Links.Commands
{
    public partial class GeneratNewShortLinkCommand : IRequest<string>
    {
        private class Handler : IRequestHandler<GeneratNewShortLinkCommand, string>
        {
            private readonly IReadRepository<Link> _linkRepository;
            private readonly IMediator _mediator;

            public Handler(IReadRepository<Link> linkRepository, IMediator mediator)
            {
                _linkRepository = linkRepository;
                _mediator = mediator;
            }

            public async Task<string> Handle(GeneratNewShortLinkCommand command, CancellationToken cancellationToken)
            {
                Random random = new Random();
                const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var shortLink = new string(Enumerable.Repeat(characters, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                if (_linkRepository.TableNoTracking.Any(c => c.ShortLink == shortLink))
                {
                    shortLink = await _mediator.Send(new GeneratNewShortLinkCommand());
                }
                return shortLink;
            }
        }
    }
}