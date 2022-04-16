using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicLibrary.Infrastructure;

namespace MigrationTest;

public class DbContextFactory : IDesignTimeDbContextFactory<MusicLibraryContext>
{
    public MusicLibraryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MusicLibraryContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicLibraryDomain;Integrated Security=True;");

        return new MusicLibraryContext(optionsBuilder.Options);
    }
}