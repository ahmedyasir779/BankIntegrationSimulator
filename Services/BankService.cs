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

        public BankService()
        {
            _adapterRegistry = new AdapterRegistry();
        }

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

            IBankAdapter adapter = _adapterRegistry.GetAdapter(bank.Code);

            BalanceResponse response = adapter.GetBalance(bank, accountNumber);

            return new BankApiResponse<BalanceResponse>
            {
                Success = true,
                Data = response
            };
        }
    }
}
