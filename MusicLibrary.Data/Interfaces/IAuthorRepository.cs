namespace MusicLibrary.Data;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorWithAlbumsAsync(int id);
}