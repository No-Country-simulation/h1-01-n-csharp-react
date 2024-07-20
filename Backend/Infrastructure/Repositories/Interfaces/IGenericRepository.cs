using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IGenericRepository<T, TId>
    {
        Task<T> Insert(T entity);
        Task<T?> GetById(TId id);
        Task<T?> GetByIdAsync(TId id, params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetAll();
        void Update(T entity);
        Task<bool> Delete(TId id);
        bool Delete(T Entity);
        Task SaveChangesAsync();
        Task InsertRange(IEnumerable<T> entities);
    }
}
