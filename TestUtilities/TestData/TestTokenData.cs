using Logic.User;

namespace TestUtilities.TestData;

public class TestTokenData
{
    public const string TestValidTokenSecretKey = "test-valid-secret-key-123451234567876543456787654";

    public static TokenGeneratorConfig TestValidTokenConfig = new()
    {
        ExpiryMinutes = 60,
        SecretKey = TestValidTokenSecretKey
    };
}