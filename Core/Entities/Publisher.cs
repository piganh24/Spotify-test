using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Publisher
    {
        [Key]
        public required int Id { get; set; }

        [Required, MinLength(1), MaxLength(160)]
        public required string Name { get; set; }

         [Required, MinLength(1), MaxLength(240)]
        public required string Description { get; set; }

        [Required, StringLength(255)]
        public required string Image { get; set; }

        [Required]
        public required bool IsDeleted { get; set; } = false;

        [Required]
        public required DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public ICollection<UserEntity>? SignedPerformer { get; set; }
    }
}
