using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class UserPlaylistsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string ProfilePicturePath { get; set; }

        public IEnumerable<SongsCollectionListItemModel> Playlists { get; set; } = Enumerable.Empty<SongsCollectionListItemModel>();
    }
}
