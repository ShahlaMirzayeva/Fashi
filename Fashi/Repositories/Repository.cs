
using Fashi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fashi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {var entity = await _dbSet.FindAsync(id);
           
                _dbSet.Remove(entity);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[]includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

       public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(p=>EF.Property<int>(p,"Id")==id);
        }

        public async Task<bool> SaveAsync()=> await _context.SaveChangesAsync()>0;


        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
