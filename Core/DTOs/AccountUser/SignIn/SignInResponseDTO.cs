namespace Core.DTOs
{
    public class SignInResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? PublisherId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsVerified { get; set; }
        public string Token { get; set; }
    }
}