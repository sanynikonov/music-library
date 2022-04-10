namespace MusicLibrary.Business.Core.Responses;

public class PagedQueryResponse<TData> : Response<TData[]>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }

    public override bool HasData => Data != null && Data.Any();

    public PagedQueryResponse(TData[] data, IList<KeyValuePair<string, string[]>> errors = null) : base(data, errors)
    {
    }
}