using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.Links;

namespace ShortLink.EfCore
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
