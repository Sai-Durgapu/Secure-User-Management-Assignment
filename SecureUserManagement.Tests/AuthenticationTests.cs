using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public void User_Login_Should_Succeed()
        {
            AuthenticationService auth =
                new AuthenticationService();

            auth.Register(
                "admin",
                "admin123",
                "admin@gmail.com");

            bool result =
                auth.Authenticate(
                    "admin",
                    "admin123");

            Assert.True(result);
        }
    }
}