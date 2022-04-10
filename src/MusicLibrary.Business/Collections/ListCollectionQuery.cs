using MediatR;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Collections;

public record ListCollectionQuery : IRequest<PagedQueryResponse<CollectionItem>>
{
    public string CollectionType { get; set; }
    public string SearchString { get; set; }
    public int PageSize { get; set; } = 100;
    public int PageNumber { get; set; } = 1;
}