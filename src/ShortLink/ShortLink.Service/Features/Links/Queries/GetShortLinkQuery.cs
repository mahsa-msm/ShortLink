using MediatR;
using ShortLink.Domain;
using ShortLink.Domain.Links;
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
            private readonly IWriteRepository<Link> _linkWriteRepository;


            public Handler(ILinkRepository LinksRepository, IWriteRepository<Link> linkWriteRepository)
            {
                _linkRepository = LinksRepository;
                _linkWriteRepository = linkWriteRepository;
            }

            public async Task<MainLinkDto> Handle(GetLinkQuery request, CancellationToken cancellationToken)
            {
                var link = await _linkRepository.GetByShortLinkAsync(request.ShortLink);

                if (link == null)
                    return null;

                link.SetVisitCount(link.VisitCount + 1);
                _linkWriteRepository.Update(link);
                await _linkWriteRepository.SaveChangeAsync();

                return new MainLinkDto { MainLink = link.MainLink };
            }
        }
    }
}