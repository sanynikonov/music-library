using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class SearchFilterModel
    {
        public string SearchString { get; set; }
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
    }

    public class SongsCollectionSearchFilterModel : SearchFilterModel
    {
        public string SongsCollectionType { get; set; }
    }
}
