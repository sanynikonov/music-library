// See https://aka.ms/new-console-template for more information

using EfCoreInheritanceTest;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EfCoreInheritanceTest;Integrated Security=True;");

await using var context = new AppDbContext(optionsBuilder.Options);

if (!context.Songs.Any() && !context.Playlists.Any())
{
    var song = new ExtendedSong { Title = "Stairway To Heaven" };
    var playlist = new ExtendedPlaylist { Title = "Led Zeppelin IV", Songs = new List<ExtendedSong> { song } };
    context.Add(song);
    context.Add(playlist);
    context.SaveChanges();
}


IRepository<Playlist> repository = new Repository<Playlist, ExtendedPlaylist>(context);

var items = await repository.Get(p => p.Songs);

Console.WriteLine(items);

//var propertyInfo = typeof(ExtendedPlaylist).GetProperties().First(p => p.DeclaringType == typeof(ExtendedPlaylist));



/*Expression<Func<Playlist, object>> expression = playlist => playlist.Songs;
Expression<Func<ExtendedPlaylist, object>> result = expression.ChangeType<Playlist, ExtendedPlaylist>();

var playlist = new ExtendedPlaylist { Songs = new List<ExtendedSong> { new() }};

var songs = result.Compile()(playlist);

Console.WriteLine(songs);*/