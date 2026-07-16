using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Contracts;
using BankIntegrationSimulator.Exceptions;
using System.IO;
using System.Text.Json;

namespace BankIntegrationSimulator.Services
{
    public class BankService : IBankService
    {

        // This method simulates a balance inquiry.
        // It receives a Bank object and an account number,
        // then returns a BankResponse object.
        public BankApiResponse<BalanceResponse> GetBalance(Bank bank, string accountNumber)
        {
            // Create a new response object.
            //BalanceResponse response = new BalanceResponse();
            if (accountNumber == "999999999")
            {
                throw new InvalidAccountException("Account does not exist.");
            }
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

            //Console.WriteLine(json);
            //Console.WriteLine(response.Balance);
            //Console.WriteLine(response.Currency);
            //Console.WriteLine(response.Status);

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

            return new BankApiResponse<BalanceResponse>
            {
                Success = true,
                Data = response
            };
        }
    }
}
