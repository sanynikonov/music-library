﻿using MusicLibrary.Business.Models;

namespace MusicLibrary.Business.Interfaces;

public interface ISongsCollectionService
{
    Task<IEnumerable<SongsCollectionListItemModel>>
        GetAllSongsCollectionsAsync(SongsCollectionSearchFilterModel filter);

    Task<SongsCollectionModel> GetSongsCollectionAsync(int id);
    Task<int> AddAsync(SongsCollectionModel model);
    Task LikeAsync(int collectionId, int userId);
}