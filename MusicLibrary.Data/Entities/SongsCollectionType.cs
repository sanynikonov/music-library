namespace MusicLibrary.Data
{
    public class SongsCollectionType : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongsCollection> SongsCollections { get; set; } = new List<SongsCollection>();
    }
}