using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Track
    {
        [Key]
        public required int Id { get; set; }

        [Required, MinLength(1), MaxLength(160)]
        public required string Title { get; set; }

        [Required, MinLength(5), MaxLength(240)]
        public required string Description { get; set; }

        [Required, StringLength(255)]
        public required string Image { get; set; }

        [Required]
        public required int Duration { get; set; }

        [Required]
        public required string Path { get; set; }

        [Required]
        public required DateTime DateCreated { get; set; }

        [Required]
        public required bool IsDeleted { get; set; } = false;

        [Required]
        public required bool IsExplicit { get; set; } = false;

        [Required]
        public required bool IsPublic { get; set; } = true;

        [Required]
        public required int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserEntity? User { get; set; }

        public int? AlbumId { get; set; }
        public virtual Album? Album { get; set; }

        public DateTime? DateUpdated { get; set; }
        public ICollection<PlaylistTrack>? PlaylistTracks { get; set; }
    }
}
