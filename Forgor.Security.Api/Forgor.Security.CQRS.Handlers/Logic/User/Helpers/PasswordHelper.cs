using System.Security.Cryptography;

namespace Forgor.Security.CQRS.Handlers.Logic.User.Helpers;

internal static class PasswordHelper
{
    public static (string Hash, string Salt) GeneratePasswordHashAndSalt(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        
        byte[] saltBytes = new byte[16];
        rng.GetBytes(saltBytes);
        string salt = Convert.ToBase64String(saltBytes);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
        
        byte[] hashBytes = pbkdf2.GetBytes(32);
        string hash = Convert.ToBase64String(hashBytes);

        return (hash, salt);
    }

    public static bool VerifyPassword(string password, string hash, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
        
        byte[] hashBytes = pbkdf2.GetBytes(32);
        string computedHash = Convert.ToBase64String(hashBytes);

        return computedHash == hash;
    }
}
