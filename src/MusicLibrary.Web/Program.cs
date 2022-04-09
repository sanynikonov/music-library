using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Business;
using MusicLibrary.Business.Collections;
using MusicLibrary.Business.Core.Behaviours;
using MusicLibrary.Business.Interfaces;
using MusicLibrary.Business.Services;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;
using MusicLibrary.Data.Interfaces;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Data.UnitOfWork;
using MusicLibrary.Web.Extensions;

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
builder.Services.AddValidatorsFromAssemblyContaining(typeof(ListCollectionQueryValidator));
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(ListCollectionQuery)))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

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

await app.SeedData();

app.Run();