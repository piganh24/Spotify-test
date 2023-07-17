namespace Core.DTOs.Identity.SignIn
{
    public class SignInUserItemDTO
    {
        /// <example>matt@gmail.com</example>
        public string Email { get; set; }

        /// <example>Qwertyuiop123@D!#da</example>
        public string Password { get; set; }
    }
}
