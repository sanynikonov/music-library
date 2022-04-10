namespace MusicLibrary.Business.Core.Responses;

public class Response
{
    public Response(IList<KeyValuePair<string, string[]>> errors = null)
    {
        Errors = errors ?? new List<KeyValuePair<string, string[]>>();
    }

    public bool IsValid => !Errors.Any();

    public IList<KeyValuePair<string, string[]>> Errors { get; }
}

public class Response<TData> : Response
{
    public TData Data { get; }
    public virtual bool HasData => Data != null;

    public Response(TData data = default, IList<KeyValuePair<string, string[]>> errors = null) : base(errors)
    {
        Data = data;
    }
}