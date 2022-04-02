using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface IAuthorService
{
    Task<AuthorModel> GetAuthorAsync(int id);
    Task<IEnumerable<AuthorListItemModel>> GetAllAuthorsAsync(SearchFilterModel filter);
}