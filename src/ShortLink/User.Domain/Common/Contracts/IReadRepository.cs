using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity<int>
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
