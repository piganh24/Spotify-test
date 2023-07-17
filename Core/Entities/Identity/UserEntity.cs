using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class UserEntity : IdentityUser<int>
    {
        [Required, MinLength(1), MaxLength(160)]
        public required string FirstName { get; set; }

        [Required, MinLength(1), MaxLength(160)]
        public required string LastName { get; set; }

        [Required, MinLength(5), MaxLength(240)]
        public required string AboutMe { get; set; }

        [StringLength(255)]
        public required string Image { get; set; }

        [Required]
        public required string UniqueVerifiacationCode { get; set; }

        [Required]
        public required bool IsDeleted { get; set; } = false;

        [Required]
        public required bool IsBloked { get; set; } = false;

        [Required]
        public required bool IsVerified { get; set; } = false;

        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<UserRoleEntity>? UserRoles { get; set; }
        public virtual ICollection<Track>? Tracks { get; set; }
        public virtual ICollection<Playlist>? Playlists { get; set; }
        public virtual ICollection<Album>? Albums { get; set; }
    }
}