using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public required string Image { get; set; }
        [StringLength(255)]
        public required string FirstName { get; set; }
        [StringLength(255)]
        public required string LastName { get; set; }
        [StringLength(255)]
        public required string Email { get; set; }
        [StringLength(255)]
        public required string Password { get; set; }
        public required bool ConfirmEmail { get; set; }
    }
}