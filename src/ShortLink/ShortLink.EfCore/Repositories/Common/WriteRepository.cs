using ShortLink.Domain;
using System.Threading.Tasks;

namespace ShortLink.EfCore.Repositories.Common
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity<int>
    {
        private readonly ApplicationDbContext _context;
        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
