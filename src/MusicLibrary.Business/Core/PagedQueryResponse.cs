namespace MusicLibrary.Business.Core;

public class PagedQueryResponse<TData> : BaseResponse
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }

    public TData[] Data { get; }
    public bool HasData => Data != null && Data.Any();

    public PagedQueryResponse(TData[] data, IList<KeyValuePair<string, string[]>> errors = null) : base(errors)
    {
        Data = data;
    }
}