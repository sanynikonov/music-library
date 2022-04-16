using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface IAuthorService
{
    Task<ArtistDetails> GetAuthorAsync(int id);
}