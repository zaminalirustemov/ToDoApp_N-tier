using System.Linq.Expressions;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task CreateAsync(T entity);
        void Update(T entity, T unchangedEntity);
        void Remove(T entity);
        IQueryable<T> GetQuery();
    }
}
