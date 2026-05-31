using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class EncryptionService
    {
        private readonly byte[] Key =
            Encoding.UTF8.GetBytes(
                "12345678901234567890123456789012");

        private readonly byte[] IV =
            Encoding.UTF8.GetBytes(
                "1234567890123456");

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor =
                aes.CreateEncryptor();

            byte[] inputBytes =
                Encoding.UTF8.GetBytes(plainText);

            byte[] encrypted =
                encryptor.TransformFinalBlock(
                    inputBytes,
                    0,
                    inputBytes.Length);

            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string cipherText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform decryptor =
                aes.CreateDecryptor();

            byte[] cipherBytes =
                Convert.FromBase64String(cipherText);

            byte[] decrypted =
                decryptor.TransformFinalBlock(
                    cipherBytes,
                    0,
                    cipherBytes.Length);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}