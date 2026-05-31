using SecureUserManagement.Models;
using SecureUserManagement.Helpers;

namespace SecureUserManagement.Services
{
    public class AuthenticationService
    {
        private readonly List<User> users =
            new();

        private readonly EncryptionService encryption =
            new();

        public void Register(
            string username,
            string password,
            string email)
        {
            string hashedPassword =
                PasswordHasher.HashPassword(password);

            string encryptedEmail =
                encryption.Encrypt(email);

            users.Add(new User
            {
                Username = username,
                HashedPassword = hashedPassword,
                EncryptedEmail = encryptedEmail
            });
        }

        public bool Authenticate(
            string username,
            string password)
        {
            User? user =
                users.FirstOrDefault(
                    u => u.Username == username);

            if (user == null)
            {
                return false;
            }

            return PasswordHasher.VerifyPassword(
                password,
                user.HashedPassword);
        }
    }
}