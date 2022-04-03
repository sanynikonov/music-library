namespace MusicLibrary.Business.Core;

public record PagedQueryResponse<TData>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public TData[] Data { get; init; }

    public bool HasData => Data != null && Data.Any();
}