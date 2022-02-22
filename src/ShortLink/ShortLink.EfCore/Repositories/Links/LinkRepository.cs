using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Links;
using ShortLink.Domain.Links.Contracts;
using ShortLink.EfCore.Repositories.Common;
using System.Threading.Tasks;

namespace ShortLink.EfCore.Repositories.Links
{
    public class LinkRepository : ReadRepository<Link>, ILinkRepository
    {
        private readonly ApplicationDbContext _context;
        public LinkRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Link> GetByShortLinkAsync(string shortLink)
        {
            return await _context.Set<Link>().FirstOrDefaultAsync(c => c.ShortLink == shortLink);
        }
    }
}
