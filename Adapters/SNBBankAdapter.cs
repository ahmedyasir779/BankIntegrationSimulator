using BankIntegrationSimulator.Models;

namespace BankIntegrationSimulator.Adapters
{
    public class SNBBankAdapter : IBankAdapter
    {
        public BalanceResponse GetBalance(Bank bank, string accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
