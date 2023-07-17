//using Core.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Infastructure
//{
//    public class SpotifyDbContext : DbContext
//    {
//        public SpotifyDbContext()
//        {

//        }

//        public SpotifyDbContext(DbContextOptions options) : base(options)
//        {

//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            #region Settig connections
//            modelBuilder.Entity<Publisher>()
//                                            .HasMany(p => p.Artists)
//                                            .WithOne(a => a.Publisher)
//                                            .HasForeignKey(a => a.PublisherId);

//            modelBuilder.Entity<Track>()
//                                        .HasOne(p => p.Genre)
//                                        .WithMany(c => c.Tracks)
//                                        .HasForeignKey(p => p.GenreId);

//            modelBuilder.Entity<Artist>()
//                                        .HasMany(a => a.Tracks)
//                                        .WithOne(t => t.Artist)
//                                        .HasForeignKey(t => t.ArtistId);

//            modelBuilder.Entity<Artist>()
//                                        .HasMany(a => a.Albums)
//                                        .WithOne(al => al.Artist)
//                                        .HasForeignKey(al => al.ArtistId);

//            modelBuilder.Entity<Track>()
//                                        .HasOne(t => t.Albom)
//                                        .WithMany(al => al.Tracks)
//                                        .HasForeignKey(t => t.AlbumId);

//            modelBuilder.Entity<Albom>()
//                                       .HasMany(a => a.Tracks)
//                                       .WithOne(t => t.Albom)
//                                       .HasForeignKey(t => t.AlbumId);

//            modelBuilder.Entity<Track>()
//                                        .HasOne(t => t.Genre)
//                                        .WithMany(g => g.Tracks)
//                                        .HasForeignKey(t => t.GenreId);

//            modelBuilder.Entity<GenrePlaylist>()
//                                                .HasKey(gp => new { gp.GenreId, gp.PlaylistId });

//            modelBuilder.Entity<GenrePlaylist>()
//                                                .HasOne(gp => gp.Genre)
//                                                .WithMany(g => g.GenrePlaylists)
//                                                .HasForeignKey(gp => gp.GenreId);

//            modelBuilder.Entity<GenrePlaylist>()
//                                                .HasOne(gp => gp.Playlist)
//                                                .WithMany(p => p.GenrePlaylists)
//                                                .HasForeignKey(gp => gp.PlaylistId);

//            #endregion

//            #region Seeding Data
//            modelBuilder.SeedPublishers();
//            modelBuilder.SeedArtists();
//            modelBuilder.SeedAlboms();
//            modelBuilder.SeedGenres();
//            modelBuilder.SeedTracks();
//            modelBuilder.SeedPlaylists();
//            modelBuilder.SeedGenrePlaylist();
//            modelBuilder.SeedAccount();
//            #endregion

//        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            base.OnConfiguring(optionsBuilder);
//        }
//        #region DbSet
//        public virtual DbSet<Publisher> Publishers { get; set; }
//        public virtual DbSet<Artist> Artists { get; set; }
//        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
//        public virtual DbSet<Track> Tracks { get; set; }
//        public virtual DbSet<Albom> Alboms { get; set; }
//        public virtual DbSet<Genre> Genres { get; set; }
//        public virtual DbSet<Playlist> Playlists { get; set; }
//        public virtual DbSet<GenrePlaylist> GenrePlaylists { get; set; }
//        public virtual DbSet<Account> Accounts { get; set; }
//        #endregion
//    }
//}