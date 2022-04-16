using AutoMapper;
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
        CreateMap<Data.Entities.Artist, AuthorModel>()
            .ReverseMap();
        CreateMap<Data.Entities.Artist, AuthorItem>()
            .ReverseMap();
        CreateMap<User, UserProfileModel>()
            .ReverseMap();
        CreateMap<User, UserPlaylistsModel>()
            .ReverseMap();
        CreateMap<Song, SongModel>()
            .ReverseMap();
        CreateMap<Collection, CollectionDetails>()
            .ReverseMap();
        CreateMap<Collection, CollectionItem>()
            .ReverseMap();
        CreateMap<ReleaseType, string>()
            .ConvertUsing(t => t.ToString());

        CreateMap<CollectionSearchFilterModel, ListCollectionQuery>();
        CreateMap<SearchFilterModel, ListAuthorsQuery>();

        CreateMap(typeof(PagedQueryResponse<>), typeof(PagedResponse<>));
    }
}