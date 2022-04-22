using System.Linq.Expressions;

namespace EfCoreInheritanceTest.DataAccess;

public interface IRepository<T>
{
    Task Add(T item);
    Task<int> Save();
    Task<T[]> Get(params Expression<Func<T, object>>[] includes);
}