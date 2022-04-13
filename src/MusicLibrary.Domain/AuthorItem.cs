namespace MusicLibrary.Domain;

public class AuthorItem : BaseEntity
{
    public string Name { get; private set; }

    public AuthorItem(string name)
    {
        Name = name;
    }
}