using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicLibrary.Data;

namespace MusicLibrary.Web
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedData(this WebApplication host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MusicLibraryContext>();

                if (context.Users.Any())
                {
                    return host;
                }

                var roleManager = services.GetRequiredService<RoleManager<Role>>();
                Role adminRole = new Role { Name = "admin" };
                Role authorRole = new Role { Name = "author" };
                Role userRole = new Role { Name = "user" };
                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(authorRole);
                await roleManager.CreateAsync(userRole);

                var userManager = services.GetRequiredService<UserManager<User>>();
                User admin = new User { Email = "admin@ukr.net", UserName = "admin", Name = "Test Admin", Bio = "Test Admin", ProfilePicturePath = "" };
                User author = new User { Email = "author@ukr.net", UserName = "author", Name = "Test Author", Bio = "Test Author", ProfilePicturePath = "" };
                User user = new User { Email = "user@ukr.net", UserName = "user", Name = "Test User", Bio = "Test User", ProfilePicturePath = "" };
                await userManager.CreateAsync(admin);
                await userManager.CreateAsync(author);
                await userManager.CreateAsync(user);

                await userManager.AddToRoleAsync(admin, adminRole.Name.ToUpper());
                await userManager.AddToRoleAsync(author, authorRole.Name.ToUpper());
                await userManager.AddToRoleAsync(user, userRole.Name.ToUpper());
            }

            return host;
        }
    }
}
