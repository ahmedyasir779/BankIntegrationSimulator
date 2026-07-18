using BankIntegrationSimulator.Models;

namespace BankIntegrationSimulator.Data
{
    public static class BankFactory
    {

        public static List<Bank> GetBanks()
        {
            return new List<Bank> {
                new Bank(
                    "Saudi National Bank",
                    "SNB",
                    "Saudi Arabia",
                    "SAR",
                    "OAuth2",
                    "https://api.snb.com",
                    true,
                    true),

                new Bank(
                    "Al Rajhi",
                    "RJHI",
                    "Saudi Arabia",
                    "SAR",
                    "Mutual TLS",
                    "https://api.alrajhi.com",
                    true,
                    true),

                new Bank(
                    "Al Riyad",
                    "RIYAD",
                    "Saudi Arabia",
                    "SAR",
                    "Mutual TLS",
                    "https://api.riyadbank.com",
                    true,
                    true),

                new Bank(
                    "Mock Bank",
                    "MOCK",
                    "UK",
                    "EUR",
                    "OAuth2",
                    "https://api.mock.com",
                    true,
                    true)
            };
        }
    }
}