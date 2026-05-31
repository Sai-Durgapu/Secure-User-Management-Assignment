using Serilog;
using SecureUserManagement.Services;

LoggingService.Configure();

AuthenticationService auth =
    new AuthenticationService();

try
{
    Console.WriteLine("===== Secure User Management System =====");

    Console.Write("\nEnter Username: ");
    string username = Console.ReadLine()!;

    Console.Write("Enter Password: ");
    string password = Console.ReadLine()!;

    Console.Write("Enter Email: ");
    string email = Console.ReadLine()!;

    auth.Register(
        username,
        password,
        email);

    Log.Information(
        "User Registered Successfully");

    Console.WriteLine(
        "\nRegistration Successful!");

    Console.WriteLine("\n===== LOGIN =====");

    Console.Write("Enter Username: ");
    string loginUsername =
        Console.ReadLine()!;

    Console.Write("Enter Password: ");
    string loginPassword =
        Console.ReadLine()!;

    bool login =
        auth.Authenticate(
            loginUsername,
            loginPassword);

    if (login)
    {
        Console.WriteLine(
            "\nLogin Successful");

        Log.Information(
            "Login Successful");
    }
    else
    {
        Console.WriteLine(
            "\nLogin Failed");

        Log.Warning(
            "Login Failed");
    }
}
catch (Exception ex)
{
    Log.Error(
        ex,
        "Application Error");

    Console.WriteLine(
        "Something went wrong.");
}
finally
{
    Log.CloseAndFlush();
}