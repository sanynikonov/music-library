using Microsoft.AspNetCore.Identity;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Web.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> SeedData(this WebApplication host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MusicLibraryContext>();

        if (!context.Users.Any())
        {
            var roleManager = services.GetRequiredService<RoleManager<Role>>();
            var adminRole = new Role { Name = "admin" };
            var authorRole = new Role { Name = "author" };
            var userRole = new Role { Name = "user" };
            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(authorRole);
            await roleManager.CreateAsync(userRole);

            var userManager = services.GetRequiredService<UserManager<User>>();
            var admin = new User
            {
                Email = "admin@ukr.net",
                UserName = "admin",
                Name = "Test Admin",
                Bio = "Test Admin",
                ProfilePicturePath = ""
            };
            var author = new User
            {
                Email = "author@ukr.net",
                UserName = "author",
                Name = "Test Artist",
                Bio = "Test Artist",
                ProfilePicturePath = ""
            };
            var user = new User
            {
                Email = "user@ukr.net",
                UserName = "user",
                Name = "Test User",
                Bio = "Test User",
                ProfilePicturePath = ""
            };
            await userManager.CreateAsync(admin);
            await userManager.CreateAsync(author);
            await userManager.CreateAsync(user);

            await userManager.AddToRoleAsync(admin, adminRole.Name.ToUpper());
            await userManager.AddToRoleAsync(author, authorRole.Name.ToUpper());
            await userManager.AddToRoleAsync(user, userRole.Name.ToUpper());
        }

        if (!context.Collections.Any())
        {
            var ledZeppelin = new Artist
            {
                Name = "Led Zeppelin",
                
            };

            var bestOfLedZeppelin = new Collection
            {
                Title = "Best of Led Zeppelin",
                UserId = 3 // User
            };

            ledZeppelin.Releases.Add(new Collection
            {
                Title = "Led Zeppelin IV",
                Type = ReleaseType.LongPlay,
                Year = 1971,
                UserId = 2, // Artist
                Songs = new List<Song>
                {
                    new Song
                    {
                        Title = "Black Dog",
                        Artists = new List<Artist> { ledZeppelin },
                        Playlists = new List<Collection> { bestOfLedZeppelin }
                    },
                    new Song
                    {
                        Title = "Rock And Roll",
                        Artists = new List<Artist> { ledZeppelin },
                        Playlists = new List<Collection> { bestOfLedZeppelin }
                    },
                    new Song
                    {
                        Title = "The Battle of Evermore",
                        Artists = new List<Artist> { ledZeppelin }
                    },
                    new Song
                    {
                        Title = "Stairway to Heaven",
                        Artists = new List<Artist> { ledZeppelin },
                        Playlists = new List<Collection> { bestOfLedZeppelin }
                    },
                    new Song
                    {
                        Title = "Misty Mountain Hop",
                        Artists = new List<Artist> { ledZeppelin }
                    },
                    new Song
                    {
                        Title = "Four Sticks",
                        Artists = new List<Artist> { ledZeppelin }
                    },
                    new Song
                    {
                        Title = "Going to California",
                        Artists = new List<Artist> { ledZeppelin }
                    },
                    new Song
                    {
                        Title = "When the Levee Breaks",
                        Artists = new List<Artist> { ledZeppelin },
                        Playlists = new List<Collection> { bestOfLedZeppelin }
                    }
                }
            });
            ledZeppelin.Releases.Add(new Collection
            {
                Title = "Black Dog",
                Type = ReleaseType.Single,
                Year = 1971,
                UserId = 2,
                Songs = new List<Song>
                {
                    new Song
                    {
                        Title = "Black Dog",
                        Artists = new List<Artist> { ledZeppelin }
                    }
                }
            });

            await context.Artists.AddAsync(ledZeppelin);
            await context.SaveChangesAsync();
        }

        return host;
    }
}