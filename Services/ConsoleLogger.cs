using BankIntegrationSimulator.Contracts;

namespace BankIntegrationSimulator.Services
{
    public class ConsoleLogger : ILoggerService
    {
        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"[WARNING] {message}");
        }
    }
}