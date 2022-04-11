using MusicLibrary.Data.Entities;

namespace MusicLibrary.Data.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorWithAlbumsAsync(int id, CancellationToken cancellationToken = default);
}