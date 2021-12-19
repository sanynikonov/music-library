using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unit;

        public SongService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<SongModel>> GetAllSongsAsync(SearchFilterModel filter)
        {
            var songs = await _unit.SongsRepository.GetAllSongsWithAuthorsAsync(s => s.Name.Contains(filter.SearchString), filter.PageNumber, filter.PageSize);
            var models = new List<SongModel>();
            foreach (var song in songs)
            {
                var songId = song.Id;
                models.Add(new SongModel
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
            return models;
        }
    }
}
