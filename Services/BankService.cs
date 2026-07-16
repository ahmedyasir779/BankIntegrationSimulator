using BankIntegrationSimulator.Models;
using BankIntegrationSimulator.Contracts;
using BankIntegrationSimulator.Exceptions;
using BankIntegrationSimulator.Adapters;
using BankIntegrationSimulator.Data;

namespace BankIntegrationSimulator.Services
{
    public class BankService : IBankService
    {

        private readonly AdapterRegistry _adapterRegistry;
        private readonly ILoggerService _logger;

        public BankService(AdapterRegistry adapterRegistry, ILoggerService logger)
        {
            _adapterRegistry = adapterRegistry;
            _logger = logger;
        }

        // This method simulates a balance inquiry.
        // It receives a Bank object and an account number,
        // then returns a BankResponse object.
        public BankApiResponse<BalanceResponse> GetBalance(Bank bank, string accountNumber)
        {

            _logger.LogInfo($"Starting balance inquiry for bank {bank.Code}");

            // Create a new response object.
            // BalanceResponse response = new BalanceResponse();
            if (accountNumber == "999999999")
            {
                _logger.LogError("Invalid account number.");
                throw new InvalidAccountException("Account does not exist.");
            }

            _logger.LogInfo($"Using adapter for {bank.Code}");
            IBankAdapter adapter = _adapterRegistry.GetAdapter(bank.Code);

            BalanceResponse response = adapter.GetBalance(bank, accountNumber);
            _logger.LogInfo("Balance inquiry completed successfully.");

            return new BankApiResponse<BalanceResponse>
            {
                Success = true,
                Data = response
            };
        }
    }
}
