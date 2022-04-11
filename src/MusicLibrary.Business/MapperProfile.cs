﻿using AutoMapper;
using MusicLibrary.Business.Authors;
using MusicLibrary.Business.Collections;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Business;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Data.Entities.Author, AuthorModel>()
            //.ForMember(x => x.Albums, c => c.MapFrom(x => x.Albums))
            .ReverseMap();
        CreateMap<Data.Entities.Author, AuthorItem>()
            .ReverseMap();
        CreateMap<User, UserProfileModel>()
            .ReverseMap();
        CreateMap<User, UserPlaylistsModel>()
            .ReverseMap();
        CreateMap<Song, SongModel>()
            .ReverseMap();
        CreateMap<SongsCollection, CollectionDetails>()
            .ReverseMap();
        CreateMap<SongsCollection, CollectionItem>()
            .ReverseMap();
        CreateMap<SongsCollectionType, string>()
            .ConvertUsing(t => t.Name);

        CreateMap<CollectionSearchFilterModel, ListCollectionQuery>();
        CreateMap<SearchFilterModel, ListAuthorsQuery>();

        CreateMap(typeof(PagedQueryResponse<>), typeof(PagedResponse<>));
    }
}