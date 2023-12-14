using Microsoft.EntityFrameworkCore;
using PruebaTecnicaDVP.DB;
using PruebaTecnicaDVP.Model;
using PruebaTecnicaDVP.Repository.IRepository;
using System.Linq.Expressions;

namespace PruebaTecnicaDVP.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TodoContext _db;
        private DbSet<T> _dbSet;

        public Repository(TodoContext db )
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await  _db.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
