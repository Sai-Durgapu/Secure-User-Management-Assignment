using Serilog;

namespace SecureUserManagement.Services
{
    public static class LoggingService
    {
        public static void Configure()
        {
            Log.Logger =
                new LoggerConfiguration()
                .WriteTo.File(
                    "logs/log.txt",
                    rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();
        }
    }
}