using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface ISongService
    {
        Task<IEnumerable<SongModel>> GetAllSongsAsync(SearchFilterModel filter);
        Task<int> AddAsync(SongModel model);
        Task LikeAsync(int songId, int userId);
    }
}
