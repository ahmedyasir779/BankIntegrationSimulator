using BankIntegrationSimulator.Models;

namespace BankIntegrationSimulator.Adapters
{
    internal class MockBankAdapter : IBankAdapter
    {
        public BalanceResponse GetBalance(Bank bank, string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
