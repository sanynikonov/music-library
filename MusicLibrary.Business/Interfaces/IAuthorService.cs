namespace MusicLibrary.Business;

public interface IAuthorService
{
    Task<AuthorModel> GetAuthorAsync(int id);
    Task<IEnumerable<AuthorListItemModel>> GetAllAuthorsAsync(SearchFilterModel filter);
}