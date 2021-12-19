using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class Song : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AudioPath { get; set; }
        public int AlbumId { get; set; }

        public SongsCollection Album { get; set; }
        public ICollection<Author> Author { get; set; } = new List<Author>();
        public ICollection<SongsCollection> Playlists { get; set; } = new List<SongsCollection>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
