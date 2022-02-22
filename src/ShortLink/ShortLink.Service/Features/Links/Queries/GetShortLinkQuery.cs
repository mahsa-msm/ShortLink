using MediatR;
using ShortLink.Domain.Links.Contracts;
using ShortLink.Service.Features.Links.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace ShortLink.Service.Features.Links.Queries
{
    public class GetLinkQuery : IRequest<MainLinkDto>
    {
        public string ShortLink { get; set; }

        private class Handler : IRequestHandler<GetLinkQuery, MainLinkDto>
        {
            private readonly ILinkRepository _linkRepository;


            public Handler(ILinkRepository LinksRepository)
            {
                _linkRepository = LinksRepository;
            }

            public async Task<MainLinkDto> Handle(GetLinkQuery request, CancellationToken cancellationToken)
            {
                var link = await _linkRepository.GetByShortLinkAsync(request.ShortLink);
                return new MainLinkDto { MainLink = link.MainLink };
            }
        }
    }
}