using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoApp_N_tier.DataAccess.Contexts;
using ToDoApp_N_tier.DataAccess.Interfaces;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ToDoContext _context;

        public Repository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter) : await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity,T unchangedEntity)
        {
            _context.Entry(unchangedEntity).CurrentValues.SetValues(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }


    }
}
