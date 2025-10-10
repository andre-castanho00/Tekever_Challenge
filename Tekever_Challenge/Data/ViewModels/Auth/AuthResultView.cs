namespace Tekever_Challenge.Data.ViewModels.Auth
{
    public class AuthResultView
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
