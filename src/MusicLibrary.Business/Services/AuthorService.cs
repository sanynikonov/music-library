using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unit;

    public AuthorService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<AuthorModel> GetAuthorAsync(int id)
    {
        var author = await _unit.AuthorsRepository.GetAuthorWithAlbumsAsync(id);
        return new AuthorModel
        {
            Id = author.Id,
            Name = author.Name,
            Albums = author.Releases.Select(a => new CollectionItem
            {
                Id = a.Id,
                Name = a.Title,
                Year = a.Year.Value,
                CollectionType = a.Type.ToString()
            }).ToArray()
        };
    }
}