using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unit;

        public AuthorService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<AuthorListItemModel>> GetAllAuthorAsync(SearchFilterModel filter)
        {
            var authors = await _unit.AuthorsRepository.GetAsync(a => a.Name.Contains(filter.SearchString), filter.PageNumber, filter.PageSize);
            var models = authors.Select(a => new AuthorListItemModel
            {
                Id = a.Id,
                Name = a.Name
            }).ToArray();
            return models;
        }

        public async Task<AuthorModel> GetAuthorAsync(int id)
        {
            var author = await _unit.AuthorsRepository.GetAsync(id);
            //TODO: use separate repository method
            var albums = await _unit.SongsCollectionsRepository.GetAsync(a => a.Authors.Select(ath => ath.Id).Contains(id));
            var type = await _unit.SongsCollectionTypesRepository.GetAsync(s => s.Id == author.Id);
            return new AuthorModel
            {
                Id = author.Id,
                Name = author.Name,
                Albums = albums.Select(a => new SongsCollectionListItemModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    SongsCollectionType = type.First().Name,
                    Year = a.Year
                })
            };
        }
    }
}
