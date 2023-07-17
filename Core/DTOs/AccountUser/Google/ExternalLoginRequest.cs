namespace Core.DTOs.Account.Google
{
    public class ExternalLoginRequest
    {
        public string Provider { get; set; }
        public string Token { get; set; }
    }
}
