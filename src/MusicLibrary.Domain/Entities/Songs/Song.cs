﻿using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities.Songs
{
    public class Song : BaseEntity, IAggregateRoot
    {
        private readonly List<Like> _likes = new();
        private readonly List<AuthorItem> _authors = new();

        public string Title { get; private set; }
        public string AudioPath { get; private set; }
        public int AlbumId { get; private set; }

        public IReadOnlyList<Like> Likes => _likes.AsReadOnly();
        public IReadOnlyList<AuthorItem> Authors => _authors.AsReadOnly();

        protected Song() {}
        public Song(SongInfo info, List<AuthorItem> authors, List<Like> likes)
        {
            Title = info.Title;
            AudioPath = info.AudioPath;
            AlbumId = info.AlbumId;
            _authors = authors;
            _likes = likes;
        }

        public void Like(int userId)
        {
            var like = _likes.FirstOrDefault(l => l.UserId == userId);
            if (like == null)
                _likes.Add(new Like(userId));
            else
                _likes.Remove(like);
        }

        public bool IsLikedBy(int userId)
        {
            return _likes.Any(l => l.UserId == userId);
        }
    }
}