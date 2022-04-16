namespace MusicLibrary.Domain.Entities;

public class CollectionInfo
{
    public int Year { get; private set; }
    public string Name { get; private set; }
    public int CreatorId { get; private set; }

    public CollectionInfo(int year, string name, int creatorId)
    {
        Year = year;
        Name = name;
        CreatorId = creatorId;
    }
}