using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Contracts;
using System.IO;
using System.Text.Json;

namespace BankIntegrationSimulator.Services
{
    public class BankService : IBankService
    {

        // This method simulates a balance inquiry.
        // It receives a Bank object and an account number,
        // then returns a BankResponse object.
        public BalanceResponse GetBalance(Bank bank, string accountNumber)
        {
            // Create a new response object.
            //BalanceResponse response = new BalanceResponse();
            string filePath = $"MockData/{bank.Code}/balance.json";
            string json = File.ReadAllText(filePath);
            BalanceResponse response = JsonSerializer.Deserialize<BalanceResponse>(json)!;

            response.AccountNumber = accountNumber;

            //response.Currency = bank.Currency;

            //response.Status = "Success";


            //switch (bank.Code)
            //{
            //    case "SNB":
            //        response.Balance = 15350.00m;
            //        break;

            //    case "RJHI":
            //        response.Balance = 8100.00m;
            //        break;

            //    case "RIYAD":
            //        response.Balance = 22900.00m;
            //        break;

            //    default:
            //        response.Balance = 5000.00m;
            //        break;
            //}

            return response;
        }
    }
}
