using Microsoft.EntityFrameworkCore;
using MusicLibrary.Business;
using MusicLibrary.Data;
using MusicLibrary.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services
    .AddDbContext<MusicLibraryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MusicLibrary")))
    .AddIdentity<User, Role>()
    .AddEntityFrameworkStores<MusicLibraryContext>();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddProfile<MapperProfile>());
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAuthorService, AuthorService>()
    .AddScoped<ISongService, SongService>()
    .AddScoped<ISongsCollectionService, SongsCollectionService>()
    .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
    .AddScoped<ISongRepository, SongRepository>()
    .AddScoped<IAuthorRepository, AuthorRepository>()
    .AddScoped<ISongsCollectionRepository, SongsCollectionRepository>()
    .AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

await app.SeedData();

app.Run();