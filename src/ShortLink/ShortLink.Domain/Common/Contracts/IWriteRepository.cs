using System.Threading.Tasks;

namespace ShortLink.Domain
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        Task SaveChangeAsync();
    }
}
