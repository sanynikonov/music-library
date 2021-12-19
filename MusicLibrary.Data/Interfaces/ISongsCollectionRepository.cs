using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public interface ISongsCollectionRepository : IRepository<SongsCollection>
    {
        Task<IEnumerable<SongsCollection>> GetAllWithAuthorsAsync(Expression<Func<SongsCollection, bool>> predicate = null, int? pageNumber = null, int? pageSize = null);
        Task<SongsCollection> GetWithAuthorsAndSongsAsync(int id);
    }
}
