using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfilePicturePath { get; set; }

        public ICollection<SongsCollection> Playlists { get; set; } = new List<SongsCollection>();
        public ICollection<SongsCollection> SavedPlaylists { get; set; } = new List<SongsCollection>();
        public ICollection<Like> LikedSongs { get; set; } = new List<Like>();
    }
}
