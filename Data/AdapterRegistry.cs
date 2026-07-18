using BankIntegrationSimulator.Adapters;
using BankIntegrationSimulator.Contracts;
using BankIntegrationSimulator.Exceptions;

namespace BankIntegrationSimulator.Data
{
    public class AdapterRegistry
    {
        private readonly Dictionary<string, IBankAdapter> _adapters;

        public AdapterRegistry()
        {
            _adapters = new Dictionary<string, IBankAdapter>
            {
                { "SNB", new SNBBankAdapter() },
                { "RJHI", new AlRajhiBankAdapter() },
                { "RIYAD", new RiyadBankAdapter() },
                { "MOCK", new MockBankAdapter() }
            };
        }

        public IBankAdapter GetAdapter(string bankCode)
        {
            if (_adapters.TryGetValue(bankCode, out IBankAdapter? adapter))
            {
                return adapter;
            }

            throw new BankNotFoundException($"No adapter found for bank '{bankCode}'.");
        }
    }
}