using Microsoft.EntityFrameworkCore;
using MusicLibrary.Infrastructure;

var builder = new DbContextOptionsBuilder<MusicLibraryContext>().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicLibraryDomain;Integrated Security=True;");
using var context = new MusicLibraryContext(builder.Options);

context.Database.EnsureCreated();

Console.WriteLine();