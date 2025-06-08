namespace TDD_Architecture.Infra.Authentication
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpirationHours { get; set; } = 2;
    }
}
