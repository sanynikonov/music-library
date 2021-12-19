using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SongsCollectionListItemModel> Albums { get; set; } = Enumerable.Empty<SongsCollectionListItemModel>();
        public IEnumerable<SongModel> TopSongs { get; set; } = Enumerable.Empty<SongModel>();
    }
}
