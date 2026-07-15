using BankIntegrationSimulator.Models;

namespace BankIntegrationSimulator.Contracts
{
    public interface IBankService
    {
        BalanceResponse GetBalance(Bank bank, string accountNumber);
    }
}