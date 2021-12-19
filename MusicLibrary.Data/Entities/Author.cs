using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class Author : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongsCollection> Albums { get; set; } = new List<SongsCollection>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
