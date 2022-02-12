using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace mycinema.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRespository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDBContext _context;
        public EntityBaseRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(n => n.id == id);
            EntityEntry entityentry = _context.Entry<T>(entity);
            entityentry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()=>await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeproperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> getByIdasnyc(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.id == id);

        public async Task update(int id, T entity)
        {
            EntityEntry entityentry= _context.Entry<T>(entity);
            entityentry.State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
