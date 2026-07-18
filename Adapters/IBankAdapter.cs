using BankIntegrationSimulator.Models;


namespace BankIntegrationSimulator.Adapters
{
    public interface IBankAdapter
    {
        BalanceResponse GetBalance(Bank bank, string accountNumber);

    }

}
