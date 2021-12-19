using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface ISongsService
    {
        Task<IEnumerable<SongModel>> GetAllAsync(SearchFilterModel filter);
    }
}
