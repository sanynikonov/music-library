using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<IEnumerable<Song>> GetAllSongsWithAuthorsAsync(Expression<Func<Song, bool>> predicate = null, int? pageNumber = null, int? pageSize = null);
    }
}
