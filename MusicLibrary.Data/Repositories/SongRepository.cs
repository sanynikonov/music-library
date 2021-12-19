using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class SongRepository : EfRepository<Song>, ISongRepository
    {
        public SongRepository(MusicLibraryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Song>> GetAllSongsWithAuthorsAsync(Expression<Func<Song, bool>> predicate = null, int? pageNumber = null, int? pageSize = null)
        {
            IQueryable<Song> query = _dbContext.Songs;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (pageNumber.HasValue && pageSize.HasValue)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query
                .Include(p => p.Author)
                .ToArrayAsync();
        }
    }
}
