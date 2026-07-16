using BankIntegrationSimulator.Models;

namespace BankIntegrationSimulator.Contracts
{
    public interface IBankService
    {
        BankApiResponse<BalanceResponse> GetBalance(Bank bank, string accountNumber);
    }
}