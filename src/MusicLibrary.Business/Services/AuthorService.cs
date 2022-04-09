﻿using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unit;

    public AuthorService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<IEnumerable<AuthorListItemModel>> GetAllAuthorsAsync(SearchFilterModel filter)
    {
        var authors = await _unit.AuthorsRepository.GetAsync(a => a.Name.Contains(filter.SearchString),
            filter.PageNumber, filter.PageSize);
        var models = authors.Select(a => new AuthorListItemModel
        {
            Id = a.Id,
            Name = a.Name
        }).ToArray();
        return models;
    }

    public async Task<AuthorModel> GetAuthorAsync(int id)
    {
        var author = await _unit.AuthorsRepository.GetAuthorWithAlbumsAsync(id);
        return new AuthorModel
        {
            Id = author.Id,
            Name = author.Name,
            Albums = author.Albums.Select(a => new CollectionItem
            {
                Id = a.Id,
                Name = a.Name,
                Year = a.Year,
                CollectionType = a.SongsCollectionType.Name
            }).ToArray()
        };
    }
}