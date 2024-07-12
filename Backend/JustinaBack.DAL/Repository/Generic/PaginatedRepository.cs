using JustinaBack.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace JustinaBack.DAL
{
    public class PaginatedRepository<T> : IRepository<T> where T : class, IDisplayNameEntity, IAuditEntity, IIdentifierEntity
    {
        private readonly WebAppContext _appContext;
        internal DbSet<T> dbSet;

        public PaginatedRepository(WebAppContext appContext)
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

        public async Task<IEnumerable<T>> GetPaginatedAsync(PaginationVM<T> model)
        {
            var isDisplay = typeof(T).GetInterfaces().Contains(typeof(IDisplayNameEntity));

            if (!isDisplay) throw new Exception("Entity must implement IDisplayNameEntity");

            var isAuditable = typeof(T).GetInterfaces().Contains(typeof(IAuditEntity));

            if (!isAuditable) throw new Exception("Entity must implement IAuditEntity");

            var isIdentifier = typeof(T).GetInterfaces().Contains(typeof(IIdentifierEntity));

            if (!isIdentifier) throw new Exception("Entity must implement IIdentifierEntity");

            var isModelValid = model.PageNumber.HasValue && model.PageSize.HasValue;

            if (!isModelValid) throw new Exception("Page and size must have value");

            int page = model.PageNumber != null ? model.PageNumber.Value : 0;
            int size = model.PageSize != null ? model.PageSize.Value : 0;

            int skip = (page - 1) * size;

            IQueryable<T> command = dbSet;

            if (!String.IsNullOrEmpty(model.SearchString))
            {
                command = command
                .Where(e => e.Deleted == null && EF.Functions.Like(e.DisplayName!, "%" + model.SearchString + "%"))
                .Skip(skip)
                .Take(size)
                .OrderBy(e => e.Id);
            }
            else
            {
                command = command
                .Where(e => e.Deleted == null)
                .Skip(skip)
                .Take(size)
                .OrderBy(e => e.Id);
            }

            return await command.ToListAsync();
        }
        #endregion
    }
}
