//using Core.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Infastructure
//{
//    public static class SeedDataExtension
//    {
//        public static void SeedGenres(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Genre>().HasData(new Genre[] {
//                new Genre
//                {
//                    Id = 1,
//                    Name = "Pop",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Description = "Popular music characterized by upbeat melodies and catchy hooks.",
//                    Image = "https://example.com/genres/pop.jpg",
//                    ShareUrl = "https://example.com/genres/pop"
//                },
//                new Genre
//                {
//                    Id = 2,
//                    Name = "Rock",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Description = "Guitar-driven music that originated in the 1950s and has evolved into various subgenres.",
//                    Image = "https://example.com/genres/rock.jpg",
//                    ShareUrl = "https://example.com/genres/rock"
//                },
//                new Genre
//                {
//                    Id = 3,
//                    Name = "Hip-Hop",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Description = "Music that originated in African American and Latino communities in the Bronx in the 1970s, characterized by rapping, beats, and samples.",
//                    Image = "https://example.com/genres/hiphop.jpg",
//                    ShareUrl = "https://example.com/genres/hiphop"
//                },
//                new Genre
//                {
//                    Id = 4,
//                    Name = "Electronic",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Description = "Music that relies heavily on electronic instruments and technology, and can range from ambient to dance-oriented.",
//                    Image = "https://example.com/genres/electronic.jpg",
//                    ShareUrl = "https://example.com/genres/electronic"
//                }
//            });
//        }

//        public static void SeedPublishers(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
//            {
//                new Publisher
//                {
//                    Id = 1,
//                    Name = "Universal Music Group",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/universalmusic.jpg",
//                    ShareUrl = "https://example.com/universalmusic",
//                    Description = "Global music corporation",
//                    DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                },
//                new Publisher
//                {
//                    Id = 2,
//                    Name = "Sony Music Entertainment",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/sonymusic.jpg",
//                    ShareUrl = "https://example.com/sonymusic",
//                    Description = "American music company",
//                    DateUpdated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                }
//            });
//        }
//        public static void SeedArtists(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Artist>().HasData(new Artist[]
//            {
//                new Artist
//                {
//                    Id = 1,
//                    PublisherId = 1,
//                    Nickname = "Picasso",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/picasso.jpg",
//                    ShareUrl = "https://example.com/picasso",
//                    Description = "Pablo Ruiz Picasso was a Spanish painter, sculptor, printmaker, ceramicist and theatre designer who spent most of his adult life in France."
//                },
//                new Artist
//                {
//                    Id = 2,
//                    PublisherId = 1,
//                    Nickname = "Van Gogh",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/vangogh.jpg",
//                    ShareUrl = "https://example.com/vangogh",
//                    Description = "Vincent Willem van Gogh was a Dutch post-impressionist painter who is among the most famous and influential figures in the history of Western art."
//                },
//                new Artist
//                {
//                    Id = 3,
//                    PublisherId = 1,
//                    Nickname = "Da Vinci",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/davinci.jpg",
//                    ShareUrl = "https://example.com/davinci",
//                    Description = "Leonardo di ser Piero da Vinci was an Italian polymath whose areas of interest included invention, drawing, painting, sculpting, architecture, science, music, mathematics, engineering, literature, anatomy, geology, astronomy, botany, writing, history, and cartography."
//                }
//            });
//        }
//        public static void SeedAlboms(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Albom>().HasData(new Albom[]
//            {
//                new Albom
//                {
//                    Id = 1,
//                    Title = "Album 1",
//                    ArtistId = 1,
//                    GenreId = 1,
//                    Duration = 60,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/album1.jpg",
//                    ShareUrl = "https://example.com/album1",
//                    Description = "This is the first album.",
//                },
//                new Albom
//                {
//                    Id = 2,
//                    Title = "Album 2",
//                    ArtistId = 1,
//                    GenreId = 2,
//                    Duration = 60,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/album1.jpg",
//                    ShareUrl = "https://example.com/album1",
//                    Description = "This is the second album.",
//                },
//                new Albom
//                {
//                    Id = 3,
//                    Title = "Album 3",
//                    ArtistId = 1,
//                    GenreId = 1,
//                    Duration = 60,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/album1.jpg",
//                    ShareUrl = "https://example.com/album1",
//                    Description = "This is the 3 album.",
//                },
//            });
//        }
//        public static void SeedTracks(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Track>().HasData(new Track[]
//            {
//                new Track
//                {
//                    Id = 1,
//                    Title = "Track1",
//                    ArtistId = 1,
//                    GenreId = 1,
//                    AlbumId = 2,
//                    Duration = 180,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Path = "/TrackStorage/Track1.mp3",
//                    Image = "onkajzly.cbc.jpg",
//                    ShareUrl = "https://example.com/track1",
//                    Description = "This is the first track by Artist1.",
//                },
//                new Track
//                {
//                    Id = 2,
//                    Title = "Track2",
//                    ArtistId = 2,
//                    GenreId = 2,
//                    AlbumId = 2,
//                    Duration = 240,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Path = "/TrackStorage/Track2.mp3",
//                    Image = "https://example.com/track2.jpg",
//                    ShareUrl = "https://example.com/track2",
//                    Description = "This is the second track by Artist2.",
//                }
//            });
//        }
//        public static void SeedPlaylists(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Playlist>().HasData(new Playlist[]
//            {
//                new Playlist
//                {
//                    Id = 1,
//                    Title = "Playlist1",
//                    Description = "This is Playlist1",
//                    Duration = 3600,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/playlist1.jpg",
//                    ShareUrl = "https://example.com/playlist1",
//                },
//                new Playlist
//                {
//                    Id = 2,
//                    Title = "Playlist2",
//                    Description = "This is Playlist2",
//                    Duration = 7200,
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/playlist2.jpg",
//                    ShareUrl = "https://example.com/playlist2"
//                }
//            });
//        }
//        public static void SeedGenrePlaylist(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<GenrePlaylist>().HasData(new GenrePlaylist[]
//            {
//                new GenrePlaylist
//                {
//                    Description = "Playlist of Rock music",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/rockplaylist.jpg",
//                    ShareUrl = "https://example.com/rockplaylist",
//                    GenreId = 1,
//                    PlaylistId = 2,
//                },
//                new GenrePlaylist
//                {
//                    Description = "Playlist of Pop music",
//                    DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
//                    Image = "https://example.com/popplaylist.jpg",
//                    ShareUrl = "https://example.com/popplaylist",
//                    GenreId = 2,
//                    PlaylistId = 2,
//                }
//            });
//        }
//        public static void SeedAccount(this ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Account>().HasData(new Account[]
//            {
//                new Account
//                {
//                    Id = 1,
//                    FirstName = "Alex",
//                    LastName = "Alex123",
//                    Email = "Alextest@gmail.com",
//                    Password = "Qwerty-1",
//                    ConfirmEmail = false,
//                    Image = "https://example.com/popplaylist.jpg",
//                },
//            });
//        }
//    }
//}
