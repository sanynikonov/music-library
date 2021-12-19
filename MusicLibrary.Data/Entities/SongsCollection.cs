﻿namespace MusicLibrary.Data
{
    public class SongsCollection : IBaseEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public int SongsCollectionTypeId { get; set; }
        public int UserAuthorId { get; set; }

        public User UserAuthor { get; set; }
        public SongsCollectionType SongsCollectionType { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}