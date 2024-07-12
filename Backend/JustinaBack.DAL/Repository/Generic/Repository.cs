using JustinaBack.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JustinaBack.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WebAppContext _appContext;
        internal DbSet<T> dbSet;

        public Repository(WebAppContext appContext)
        {
            _appContext = appContext;
            dbSet = _appContext.Set<T>();
        }

        #region Synchronous
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
        EntityEntry IRepository<T>.Add(T entity)
        {
            return dbSet.Add(entity);
        }
        public T? GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(expression);

            return query.FirstOrDefault();
        }
        public EntityEntry Remove(T entity)
        {
            return dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
        #endregion

        #region Async
        public async Task<EntityEntry> AddAsync(T entity)
        {
            return await dbSet.AddAsync(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }
        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(expression);

            return await query.FirstOrDefaultAsync();
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public Task<IEnumerable<T>> GetPaginatedAsync(PaginationVM<T> model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
