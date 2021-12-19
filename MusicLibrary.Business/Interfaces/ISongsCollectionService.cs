using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface ISongsCollectionService
    {
        Task<IEnumerable<SongsCollectionListItemModel>> GetAllSongsCollectionsAsync(SongsCollectionSearchFilterModel filter);
        Task<SongsCollectionModel> GetSongsCollectionAsync(int id);
        Task<int> AddAsync(SongsCollectionModel model);
        Task LikeAsync(int collectionId, int userId);
    }
}
