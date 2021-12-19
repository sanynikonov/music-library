using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    internal interface ISongsCollectionService
    {
        Task<IEnumerable<SongsCollectionListItemModel>> GetAllSongsCollectionsAsync(SearchFilterModel filter);
        Task<SongsCollectionModel> GetSongsCollectionAsync(int id);
    }
}
