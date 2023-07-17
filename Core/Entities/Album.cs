using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Album
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
        public int Duration { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Required]
        public required bool IsDeleted { get; set; } = false;

        [Required]
        public required bool IsExplicit { get; set; } = false;

        [Required]
        public required bool IsPublic { get; set; } = true;

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
