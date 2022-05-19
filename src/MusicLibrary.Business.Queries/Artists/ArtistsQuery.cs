using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Artists;

public class ArtistsQuery : IRequest<PagedQueryResponse<ArtistItem>>
{
    public string SearchString { get; set; }
    public int PageSize { get; set; } = 20;
    public int PageNumber { get; set; } = 1;
}