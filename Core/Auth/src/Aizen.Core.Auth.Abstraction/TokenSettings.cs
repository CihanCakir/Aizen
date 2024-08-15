namespace Aizen.Core.Auth.Abstraction
{
    public class TokenSettings
    {
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
    }
}