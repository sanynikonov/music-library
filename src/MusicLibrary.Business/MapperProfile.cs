using AutoMapper;
using MusicLibrary.Business.Artists;
using MusicLibrary.Business.Collections;
using MusicLibrary.Business.Core.Responses;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Business;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Artist, ArtistDetails>()
            .ReverseMap();
        CreateMap<Artist, ArtistItem>()
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
        CreateMap<SearchFilterModel, ListArtistsQuery>();

        CreateMap(typeof(PagedQueryResponse<>), typeof(PagedResponse<>));
    }
}