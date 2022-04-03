namespace MusicLibrary.Business.Models;

public record PagedResponse<TData>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public TData[] Data { get; init; }
}