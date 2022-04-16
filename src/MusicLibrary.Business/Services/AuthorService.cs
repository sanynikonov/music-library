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

    public async Task<ArtistDetails> GetAuthorAsync(int id)
    {
        var author = await _unit.AuthorsRepository.GetAuthorWithAlbumsAsync(id);
        return new ArtistDetails
        {
            Id = author.Id,
            Name = author.Name,
            Albums = author.Releases.Select(a => new CollectionItem
            {
                Id = a.Id,
                Title = a.Title,
                Year = a.Year.Value,
                Type = a.Type.ToString()
            }).ToArray()
        };
    }
}