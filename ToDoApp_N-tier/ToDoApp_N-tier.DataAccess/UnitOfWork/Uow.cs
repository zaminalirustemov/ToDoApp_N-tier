using ToDoApp_N_tier.DataAccess.Contexts;
using ToDoApp_N_tier.DataAccess.Interfaces;
using ToDoApp_N_tier.DataAccess.Repositories;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ToDoContext _context;

        public Uow(ToDoContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
