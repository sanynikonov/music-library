// See https://aka.ms/new-console-template for more information

using AutoMapper;
using MusicLibrary.Business;
using MusicLibrary.Business.Models;
using MusicLibrary.Data.Entities;

Console.WriteLine("Hello, World!");
var mapper = new Mapper(new MapperConfiguration(opt => opt.AddProfile<MapperProfile>()));

var author = new Author
{
    Id = 1,
    Name = "Author",
    Albums = new SongsCollection[]
    {
        new()
        {
            Id = 1, Name = "Collection 1", SongsCollectionTypeId = 1, Year = 2010, UserAuthorId = 1,
            SongsCollectionType = new SongsCollectionType {Name = "Album"}
        },
        new()
        {
            Id = 2, Name = "Collection 2", SongsCollectionTypeId = 1, Year = 2012, UserAuthorId = 1,
            SongsCollectionType = new SongsCollectionType {Name = "Album"}
        }
    }
};

var model = mapper.Map<AuthorModel>(author);
Console.WriteLine();