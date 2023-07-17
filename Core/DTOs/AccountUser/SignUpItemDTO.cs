namespace Core.DTOs.Identity
{
    public class SignUpItemDTO
    {
        /// <example>Elizabet</example>
        public string FirstName { get; set; }

        /// <example>Woolridge</example>
        public string LastName { get; set; }

        /// <example>Lana Del Rey</example>
        public string UserName { get; set; }

        /// <example>lana@gmail.com</example>
        public string Email { get; set; }

        /// <example>Elizabeth Woolridge Grant, known professionally as Lana Del Rey, is an American singer-songwriter</example>
        public string AboutMe { get; set; }

        /// <example>INSERT BASE64</example>
        public string Image { get; set; }

        /// <example>Qwertyuiop123@D!#da</example>
        public string Password { get; set; }

        /// <example>Qwertyuiop123@D!#da</example>
        public string ConfirmPassword { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public int? PublisherId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsVerified { get; set; }
    }
}