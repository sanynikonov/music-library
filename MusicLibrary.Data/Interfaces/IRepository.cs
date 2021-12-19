using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null, int? pageNumer = null, int? pageSize = null);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
