using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Data
{
    public class Like : IBaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SongId { get; set; }
        public User User { get; set; }
        public Song Song { get; set; }
    }
}
