using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class SongsCollectionService : ISongsCollectionService
    {
        private readonly IUnitOfWork _unit;

        public SongsCollectionService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<SongsCollectionListItemModel>> GetAllSongsCollectionsAsync(SongsCollectionSearchFilterModel filter)
        {
            var collections = await _unit.SongsCollectionsRepository.GetAllWithAuthorsAsync(c => c.Name.Contains(filter.SearchString), filter.PageNumber, filter.PageSize);

            return collections.Select(c => new SongsCollectionListItemModel
            {
                Id = c.Id,
                Name = c.Name,
                Year = c.Year,
                SongsCollectionType = c.SongsCollectionType.Name
            }).ToArray();
        }

        public async Task<SongsCollectionModel> GetSongsCollectionAsync(int id)
        {
            var collection = await _unit.SongsCollectionsRepository.GetWithAuthorsAndSongsAsync(id);

            var model = new SongsCollectionModel
            {
                Id = collection.Id,
                Name = collection.Name,
                Year = collection.Year,
                SongsCollectionType = collection.SongsCollectionType.Name,
                UserAuthorId = collection.UserAuthorId,
                Authors = collection.Authors.Select(a => new AuthorListItemModel
                {
                    Id = a.Id,
                    Name = a.Name,
                })
            };

            var songs = new List<SongModel>();
            foreach (var song in collection.Songs)
            {
                var songId = song.Id;
                songs.Add(new SongModel
                {
                    Name = song.Name,
                    Id = song.Id,
                    AlbumId = song.AlbumId,
                    AudioPath = song.AudioPath,
                    Authors = song.Author.Select(a => new AuthorListItemModel
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToArray(),
                    LikesCount = await _unit.LikesRepository.CountAsync(l => songId == l.SongId)
                });
            }

            model.Songs = songs;
            return model;
        }
    }
}
