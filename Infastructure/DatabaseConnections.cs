using Core.Entities.Identity;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infastructure
{
    public class DatabaseConnections
    {
        public static void SetDbConnections(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleEntity>(user =>
            {
                user.HasKey(user => new { user.UserId, user.RoleId });

                user.HasOne(user => user.Role)
                        .WithMany(role => role.UserRoles)
                        .HasForeignKey(role => role.RoleId)
                        .IsRequired();

                user.HasOne(user => user.User)
                        .WithMany(role => role.UserRoles)
                        .HasForeignKey(user => user.UserId)
                        .IsRequired();
            });

            modelBuilder.Entity<Publisher>()
                        .HasMany(publisher => publisher.SignedPerformer)
                        .WithOne(user => user.Publisher)
                        .HasForeignKey(user => user.PublisherId);

            modelBuilder.Entity<Track>()
                        .HasOne(track => track.Genre)
                        .WithMany(genre => genre.Tracks)
                        .HasForeignKey(track => track.GenreId);

            modelBuilder.Entity<UserEntity>()
                        .HasMany(a => a.Tracks)
                        .WithOne(t => t.User)
                        .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Track>()
                        .HasOne(t => t.Album)
                        .WithMany(al => al.Tracks)
                        .HasForeignKey(t => t.AlbumId);

            modelBuilder.Entity<Album>()
                        .HasMany(a => a.Tracks)
                        .WithOne(t => t.Album)
                        .HasForeignKey(t => t.AlbumId);

            modelBuilder.Entity<Track>()
                        .HasOne(t => t.Genre)
                        .WithMany(g => g.Tracks)
                        .HasForeignKey(t => t.GenreId);
        }
    }
}
