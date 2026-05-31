using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void Encrypt_Decrypt_Should_Work()
        {
            EncryptionService service =
                new EncryptionService();

            string original =
                "Hello Wipro";

            string encrypted =
                service.Encrypt(original);

            string decrypted =
                service.Decrypt(encrypted);

            Assert.Equal(
                original,
                decrypted);
        }
    }
}