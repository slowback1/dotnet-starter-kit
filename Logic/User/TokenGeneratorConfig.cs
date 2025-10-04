namespace Logic.User;

public class TokenGeneratorConfig
{
    public string SecretKey { get; set; }
    public int ExpiryMinutes { get; set; } = 60;
}