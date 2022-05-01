using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.Domain
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(List<TEntity> entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entity);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entity);
    }
}
