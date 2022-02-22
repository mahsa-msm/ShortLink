using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Domain.Links.Contracts
{
    public interface ILinkRepository : IReadRepository<Link>
    {
        Task<Link> GetByShortLinkAsync(string shortLink);
    }
}
