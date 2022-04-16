using MusicLibrary.Domain.Common;

namespace MusicLibrary.Domain.Entities.Songs
{
    public class Song : BaseEntity, IAggregateRoot
    {
        private readonly List<Like> _likes = new();
        private readonly List<ArtistItem> _artists = new();

        public SongInfo Info { get; private set; }
        public IReadOnlyList<Like> Likes => _likes.AsReadOnly();
        public IReadOnlyList<ArtistItem> Artists => _artists.AsReadOnly();

        protected Song() {}
        public Song(SongInfo info, List<ArtistItem> artists, List<Like> likes)
        {
            Info = info!;
            _artists = artists!;
            _likes = likes!;
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