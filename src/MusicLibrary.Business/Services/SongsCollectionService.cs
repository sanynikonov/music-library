﻿using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.UnitOfWork;

namespace MusicLibrary.Business.Services;

public class SongsCollectionService : ISongsCollectionService
{
    private readonly IUnitOfWork _unit;

    public SongsCollectionService(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<SongsCollectionModel> GetSongsCollectionAsync(int id)
    {
        var collection = await _unit.SongsCollectionsRepository.GetWithAuthorsAndSongsAndTypesAsync(id);

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
                Name = a.Name
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
                Authors = song.Authors.Select(a => new AuthorListItemModel
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

    public async Task<int> AddAsync(SongsCollectionModel model)
    {
        //var names = model.Authors.Select(a => a.Name).ToArray();
        //var authors = await _unit.AuthorsRepository.GetAsync(a => names.Contains(a.Name));
        //var existingAuthorsIds = authors.Select(a => a.Id).ToArray();
        //var newAuthors = model.Authors.Where(a => existingAuthorsIds.Contains(a.Id)).Select();
        var collection = new SongsCollection
        {
            Name = model.Name,
            Year = model.Year,
            Authors = model.Authors.Select(a => new Author {Name = a.Name}).ToArray()
        };

        await _unit.SongsCollectionsRepository.AddAsync(collection);
        await _unit.SaveChangesAsync();

        return collection.Id;
    }

    public async Task LikeAsync(int collectionId, int userId)
    {
        var collection = await _unit.SongsCollectionsRepository.GetWithAuthorsAndSongsAndTypesAsync(userId);
        var songsIds = collection.Songs.Select(x => x.Id).ToArray();
        var likes = await _unit.LikesRepository.GetAsync(l => l.UserId == userId && songsIds.Contains(l.SongId));
        var unlikedSongs = songsIds.Except(likes.Select(x => x.SongId)).ToArray();
        foreach (var id in unlikedSongs) await _unit.LikesRepository.AddAsync(new Like {SongId = id, UserId = userId});
        await _unit.SaveChangesAsync();
    }
}