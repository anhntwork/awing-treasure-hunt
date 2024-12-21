using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IRepository<TEntity, TKeyType> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TKeyType id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}