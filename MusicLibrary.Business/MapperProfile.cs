using AutoMapper;
using MusicLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Business
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorModel>()
                .ForMember(x => x.Albums, c => c.MapFrom(x => x.Albums))
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
        }
    }
}
