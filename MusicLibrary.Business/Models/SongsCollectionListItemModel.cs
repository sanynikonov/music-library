using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class SongsCollectionListItemModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string SongsCollectionType { get; set; }
    }
}
