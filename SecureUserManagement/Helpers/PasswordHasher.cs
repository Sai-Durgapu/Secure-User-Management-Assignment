using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using SHA256 sha = SHA256.Create();

            byte[] bytes =
                sha.ComputeHash(
                    Encoding.UTF8.GetBytes(password));

            StringBuilder builder =
                new StringBuilder();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool VerifyPassword(
            string password,
            string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }
}