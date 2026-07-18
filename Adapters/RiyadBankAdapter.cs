using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Exceptions;
using System.IO;
using System.Text.Json;

namespace BankIntegrationSimulator.Adapters
{
    public class RiyadBankAdapter : IBankAdapter
    {
        public BalanceResponse GetBalance(Bank bank, string accountNumber)
        {
            string filePath = $"MockData/{bank.Code}/balance.json";

            if (!File.Exists(filePath))
            {
                throw new BankNotFoundException($"Bank '{bank.Code}' was not found.");
            }

            string json = File.ReadAllText(filePath);

            BalanceResponse response =
            JsonSerializer.Deserialize<BalanceResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

             response.AccountNumber = accountNumber;

            return response;
        }
    }
}
