using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public interface IAuthorService
    {
        Task<AuthorModel> GetAuthorAsync(int id);
        Task<IEnumerable<AuthorListItemModel>> GetAllAuthorsAsync(SearchFilterModel filter);
    }
}
