using AutoMapper;
using MusicLibrary.Business.Models;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Business;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Author, AuthorModel>()
            //.ForMember(x => x.Albums, c => c.MapFrom(x => x.Albums))
            .ReverseMap();
        CreateMap<Author, AuthorListItemModel>()
            .ReverseMap();
        CreateMap<User, UserProfileModel>()
            .ReverseMap();
        CreateMap<User, UserPlaylistsModel>()
            .ReverseMap();
        CreateMap<Song, SongModel>()
            .ReverseMap();
        CreateMap<SongsCollection, SongsCollectionModel>()
            .ReverseMap();
        CreateMap<SongsCollection, SongsCollectionListItemModel>()
            .ReverseMap();
        CreateMap<SongsCollectionType, string>()
            .ConvertUsing(t => t.Name);
    }
}