namespace MusicLibrary.Business.Core;

public abstract class BaseResponse
{
    protected BaseResponse(IList<KeyValuePair<string, string[]>> errors = null)
    {
        Errors = errors ?? new List<KeyValuePair<string, string[]>>();
    }

    public bool IsValid => !Errors.Any();

    public IList<KeyValuePair<string, string[]>> Errors { get; }
}