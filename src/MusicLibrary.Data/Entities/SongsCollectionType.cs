namespace MusicLibrary.Data.Entities;

public class SongsCollectionType : IBaseEntity
{
    public string Name { get; set; }
    public ICollection<SongsCollection> SongsCollections { get; set; } = new List<SongsCollection>();
    public int Id { get; set; }
}