using Core.Entities;
using Core.Entities.Identity;
using Core.Resources.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infastructure
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<DatabaseContext>();
                var userNamager = service.GetRequiredService<UserManager<UserEntity>>();

                if (!context.Roles.Any())
                {
                    RoleEntity userRoleEntity = new RoleEntity()
                    {
                        Id = 1,
                        Name = Roles.User,
                        NormalizedName = Roles.User.ToUpper()
                    };
                    await context.Roles.AddAsync(userRoleEntity);
                    await context.SaveChangesAsync();

                    RoleEntity adminRoleEntity = new RoleEntity()
                    {
                        Id = 2,
                        Name = Roles.Admin,
                        NormalizedName = Roles.Admin.ToUpper()
                    };
                    await context.Roles.AddAsync(adminRoleEntity);
                    await context.SaveChangesAsync();
                }
                if (!context.Users.Any())
                {
                    var user = new UserEntity()
                    {
                        Id = 1,
                        FirstName = "Matt",
                        LastName = "Daymon",
                        UserName = "matteree",
                        AboutMe = "The best",
                        Image = "1.default.jpg",
                        Email = "email@gmail.com",
                        PublisherId = 1,
                        IsDeleted = false,
                        IsBloked = false,
                        IsVerified = false,
                        UniqueVerifiacationCode = Guid.NewGuid().ToString(),
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                    };
                    var result = await userNamager.CreateAsync(user, "Qwertyuiop123@D!#da");
                    if (result.Succeeded)
                    {
                        result = await userNamager.AddToRoleAsync(user, Roles.User);
                    }
                }
                if (!context.Publishers.Any())
                {
                    Publisher publisher = new Publisher()
                    {
                        Id = 1,
                        Name = "Universal Music Group",
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Image = "1.default.jpg",
                        Description = "Global music corporation",
                        DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        IsDeleted = false,

                    };
                    await context.Publishers.AddAsync(publisher);
                    await context.SaveChangesAsync();
                }
                if (!context.Albums.Any())
                {
                    Album album = new Album()
                    {
                        Id = 1,
                        Title = "Album 1",
                        UserId = 1,
                        GenreId = 1,
                        Duration = 60,
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Image = "1.default.jpg",
                        Description = "This is the first album.",
                        IsDeleted = false,
                        IsExplicit = false,
                        IsPublic = false,
                    };
                    await context.Albums.AddAsync(album);
                    await context.SaveChangesAsync();
                }
                if (!context.Genres.Any())
                {
                    Genre genre = new Genre()
                    {
                        Id = 1,
                        Name = "Pop",
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Description = "Popular music characterized by upbeat melodies and catchy hooks.",
                        Image = "1.default.jpg",
                        IsDeleted = false,

                    };
                    await context.Genres.AddAsync(genre);
                    await context.SaveChangesAsync();
                }
                if (!context.Tracks.Any())
                {
                    Track track = new Track()
                    {
                        Id = 1,
                        Title = "Track 1",
                        UserId = 5,
                        AlbumId = 1,
                        GenreId = 1,
                        Duration = 300,
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Path = "test.mp3",
                        Image = "1.default.jpg",
                        Description = "Rock",
                        IsDeleted = false,
                        IsExplicit = false,
                        IsPublic = false,
                    };
                    await context.Tracks.AddAsync(track);
                    await context.SaveChangesAsync();
                }
                if (!context.Playlists.Any())
                {
                    Playlist playlist = new Playlist()
                    {
                        Id = 1,
                        Title = "Playlist1",
                        Description = "This is Playlist1",
                        Duration = 3600,
                        UserId = 1,
                        DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        Image = "1.default.jpg",
                        IsDeleted = false,
                        IsExplicit = false,
                        IsPublic = false,
                    };
                    await context.Playlists.AddAsync(playlist);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
