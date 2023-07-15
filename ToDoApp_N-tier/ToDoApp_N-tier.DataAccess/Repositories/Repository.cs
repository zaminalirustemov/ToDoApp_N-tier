using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        public void Update(T entity)
        {
            var updatedEntity= _context.Set<T>().Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
        }

        public void Remove(object id)
        {
            var deletedEntity=_context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }


    }
}
