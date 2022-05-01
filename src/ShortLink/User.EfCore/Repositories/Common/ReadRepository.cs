using Microsoft.EntityFrameworkCore;
using User.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.EfCore.Repositories.Common
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity<int>
    {
        private readonly ApplicationDbContext _context;
        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Table => _context.Set<TEntity>();
        public virtual IQueryable<TEntity> TableNoTracking => _context.Set<TEntity>().AsNoTracking();

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
