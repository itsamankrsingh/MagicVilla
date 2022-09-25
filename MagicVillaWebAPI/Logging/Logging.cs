using MagicVillaWebAPI.Interfaces;

namespace MagicVillaWebAPI.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error Message -> {message}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Warn:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Warn Message -> {message}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Info:
                    Console.WriteLine(message);
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
        }
    }
}
