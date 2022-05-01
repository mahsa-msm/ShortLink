using User.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace User.EfCore.Repositories.Common
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
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(List<TEntity> entity)
        {
            await _context.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<TEntity> entity)
        {
            _context.Set<TEntity>().UpdateRange(entity);
            await _context.SaveChangesAsync();
        }
    }
}
