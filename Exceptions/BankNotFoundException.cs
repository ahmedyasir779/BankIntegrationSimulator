

namespace BankIntegrationSimulator.Exceptions
{
    public class BankNotFoundException : IntegrationException
    {
        public BankNotFoundException(string message) : base(message)
        {
        }
    }
}
