
namespace BankIntegrationSimulator.Exceptions
{
    public class BankUnavailableException : IntegrationException
    {
        public BankUnavailableException(string message) : base(message)
        {
        }
    }
}
