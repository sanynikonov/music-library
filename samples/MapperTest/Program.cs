// See https://aka.ms/new-console-template for more information

using AutoMapper;
using MusicLibrary.Business;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;

Console.WriteLine("Hello, World!");
var mapper = new Mapper(new MapperConfiguration(opt => opt.AddProfile<MapperProfile>()));

var author = new Artist
{
    Id = 1,
    Name = "Artist",
    Releases = new Collection[]
    {
        new()
        {
            Id = 1, Title = "Collection 1", Year = 2010, UserId = 1,
            Type = ReleaseType.LongPlay
        },
        new()
        {
            Id = 2, Title = "Collection 2", Year = 2012, UserId = 1,
            Type = ReleaseType.LongPlay
        }
    }
};

var model = mapper.Map<ArtistDetails>(author);
Console.WriteLine();