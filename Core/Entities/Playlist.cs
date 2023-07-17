using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Playlist
    {
        [Key]
        public required int Id { get; set; }

        [Required, MinLength(1), MaxLength(160)]
        public required string Title { get; set; }

        [Required, MinLength(1), MaxLength(100)]
        public required string Description { get; set; }

        [StringLength(255)]
        public required string Image { get; set; }

        [Required]
        public required int Duration { get; set; }

        [Required]
        public required DateTime DateCreated { get; set; }

        [Required]
        public required bool IsDeleted { get; set; } = false;

        [Required]
        public required bool IsExplicit { get; set; } = false;

        [Required]
        public required bool IsPublic { get; set; } = true;

        public DateTime? DateUpdated { get; set; }

        public int? GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public ICollection<PlaylistTrack>? PlaylistTracks { get; set; }
    }
}
