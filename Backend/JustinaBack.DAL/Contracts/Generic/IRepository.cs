using JustinaBack.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;


namespace JustinaBack.DAL
{
    public interface IRepository<T> where T : class
    {
        #region Synchronous
        IEnumerable<T> GetAll();
        EntityEntry Add(T entity);
        T? GetFirstOrDefault(Expression<Func<T, bool>> expression);
        EntityEntry Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        #endregion

        #region Async
        Task<EntityEntry> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetPaginatedAsync(PaginationVM<T> model);
        #endregion
    }
}
