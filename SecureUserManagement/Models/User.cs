namespace SecureUserManagement.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;

        public string HashedPassword { get; set; } = string.Empty;

        public string EncryptedEmail { get; set; } = string.Empty;
    }
}