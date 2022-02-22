using MediatR;
using ShortLink.Domain.Links.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace ShortLink.Service.Features.Links.Queries
{
    public class GetVisitCountQuery : IRequest<long>
    {
        public string ShortLink { get; set; }

        private class Handler : IRequestHandler<GetVisitCountQuery, long>
        {
            private readonly ILinkRepository _linkRepository;


            public Handler(ILinkRepository LinksRepository)
            {
                _linkRepository = LinksRepository;
            }

            public async Task<long> Handle(GetVisitCountQuery request, CancellationToken cancellationToken)
            {
                var link = await _linkRepository.GetByShortLinkAsync(request.ShortLink);
                return link.VisitCount;
            }
        }
    }
}